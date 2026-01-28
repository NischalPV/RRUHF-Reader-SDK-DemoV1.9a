using System.Net;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using RRUHFReaderService.Data;
using RRUHFReaderService.Models;
using RRUHFReaderService.Protocol;

namespace RRUHFReaderService.Services;

public class TcpReaderListenerService : BackgroundService
{
    private readonly ILogger<TcpReaderListenerService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;
    private TcpListener? _listener;
    private readonly List<ClientConnection> _clients = new();
    private readonly object _clientsLock = new();

    public TcpReaderListenerService(
        ILogger<TcpReaderListenerService> logger,
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var host = _configuration.GetValue<string>("TcpListener:Host") ?? "0.0.0.0";
        var port = _configuration.GetValue<int>("TcpListener:Port", 8888);

        _logger.LogInformation("Starting TCP Listener on {Host}:{Port}", host, port);

        try
        {
            // Validate and parse IP address
            if (!IPAddress.TryParse(host, out var ipAddress))
            {
                _logger.LogError("Invalid IP address configured: {Host}", host);
                return;
            }

            _listener = new TcpListener(ipAddress, port);
            _listener.Start();
            _logger.LogInformation("TCP Listener started successfully");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync(stoppingToken);
                    var endpoint = client.Client.RemoteEndPoint?.ToString();
                    _logger.LogInformation("New client connected: {Endpoint}", endpoint);

                    var connection = new ClientConnection(client, endpoint ?? "unknown");
                    lock (_clientsLock)
                    {
                        _clients.Add(connection);
                    }

                    // Handle client in background task with proper exception handling
                    _ = HandleClientAsync(connection, stoppingToken).ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                        {
                            _logger.LogError(t.Exception, "Error in client handler for {Endpoint}", connection.Endpoint);
                        }
                    }, TaskScheduler.Default);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error accepting client connection");
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fatal error in TCP Listener");
        }
        finally
        {
            _listener?.Stop();
            lock (_clientsLock)
            {
                foreach (var client in _clients)
                {
                    client.Dispose();
                }
                _clients.Clear();
            }
        }
    }

    private async Task HandleClientAsync(ClientConnection connection, CancellationToken stoppingToken)
    {
        var parser = new FrameParser();
        parser.PacketReceived += async (sender, packet) =>
        {
            await ProcessPacketAsync(packet, connection.Endpoint);
        };

        try
        {
            var stream = connection.Client.GetStream();
            var buffer = new byte[4096];

            while (!stoppingToken.IsCancellationRequested && connection.Client.Connected)
            {
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, stoppingToken);
                if (bytesRead == 0)
                    break;

                var data = new byte[bytesRead];
                Array.Copy(buffer, data, bytesRead);

                _logger.LogDebug("Received {Bytes} bytes from {Endpoint}: {Data}",
                    bytesRead, connection.Endpoint, BitConverter.ToString(data));

                parser.ProcessData(data);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Client handler cancelled for {Endpoint}", connection.Endpoint);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling client {Endpoint}", connection.Endpoint);
        }
        finally
        {
            _logger.LogInformation("Client disconnected: {Endpoint}", connection.Endpoint);
            lock (_clientsLock)
            {
                _clients.Remove(connection);
            }
            connection.Dispose();
        }
    }

    private async Task ProcessPacketAsync(byte[] packet, string endpoint)
    {
        try
        {
            if (packet.Length < 1)
                return;

            byte cmdCode = packet[0];

            // Process inventory responses (0xE0)
            if (cmdCode == 0xE0)
            {
                var response = FrameParser.ParseInventoryResponse(packet);
                if (response != null)
                {
                    await SaveInventoryResponseAsync(response, endpoint);
                }
            }
            else
            {
                _logger.LogDebug("Received packet with command code 0x{CmdCode:X2} from {Endpoint}",
                    cmdCode, endpoint);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing packet from {Endpoint}", endpoint);
        }
    }

    private async Task SaveInventoryResponseAsync(InventoryResponse response, string endpoint)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ReaderDbContext>();

            // Parse endpoint to get IP and port
            string? ipAddress = null;
            int port = 0;
            
            // Handle both IPv4 (192.168.1.1:8080) and IPv6 ([::1]:8080) formats
            var lastColonIndex = endpoint.LastIndexOf(':');
            if (lastColonIndex > 0)
            {
                ipAddress = endpoint.Substring(0, lastColonIndex).Trim('[', ']');
                int.TryParse(endpoint.Substring(lastColonIndex + 1), out port);
            }

            // Find or create reader
            var reader = await dbContext.Readers
                .FirstOrDefaultAsync(r => r.DeviceId == response.DeviceId);

            if (reader == null)
            {
                reader = new Reader
                {
                    DeviceId = response.DeviceId,
                    IpAddress = ipAddress,
                    Port = port,
                    FirstSeenAt = DateTime.UtcNow,
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true
                };
                dbContext.Readers.Add(reader);
                await dbContext.SaveChangesAsync();
                _logger.LogInformation("New reader registered: DeviceId={DeviceId}, IP={IpAddress}",
                    response.DeviceId, ipAddress);
            }
            else
            {
                reader.LastSeenAt = DateTime.UtcNow;
                reader.IsActive = true;
                if (!string.IsNullOrEmpty(ipAddress))
                    reader.IpAddress = ipAddress;
                if (port > 0)
                    reader.Port = port;
            }

            // Find or create tag
            var tag = await dbContext.Tags
                .FirstOrDefaultAsync(t => t.Epc == response.Epc && t.ReaderId == reader.Id);

            if (tag == null)
            {
                tag = new Tag
                {
                    Epc = response.Epc,
                    Tid = response.Tid,
                    UserMemory = response.UserMemory,
                    ReaderId = reader.Id,
                    FirstSeenAt = DateTime.UtcNow,
                    LastSeenAt = DateTime.UtcNow,
                    TotalReadCount = 1
                };
                dbContext.Tags.Add(tag);
                _logger.LogInformation("New tag detected: EPC={Epc}, TID={Tid}",
                    response.Epc, response.Tid);
            }
            else
            {
                tag.LastSeenAt = DateTime.UtcNow;
                tag.TotalReadCount++;
                
                // Update TID and UserMemory if present
                if (!string.IsNullOrEmpty(response.Tid))
                    tag.Tid = response.Tid;
                if (!string.IsNullOrEmpty(response.UserMemory))
                    tag.UserMemory = response.UserMemory;
            }

            await dbContext.SaveChangesAsync();

            // Create transaction record
            var transaction = new TagTransaction
            {
                TagId = tag.Id,
                ReaderId = reader.Id,
                DetectedAt = DateTime.UtcNow,
                Rssi = response.Rssi,
                AntennaId = response.AntennaId,
                ReaderTimestamp = response.Timestamp,
                RawData = BitConverter.ToString(response.RawData).Replace("-", "")
            };

            dbContext.TagTransactions.Add(transaction);
            await dbContext.SaveChangesAsync();

            _logger.LogDebug("Tag transaction saved: EPC={Epc}, RSSI={Rssi}, Antenna={Antenna}",
                response.Epc, response.Rssi, response.AntennaId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving inventory response to database");
        }
    }

    private class ClientConnection : IDisposable
    {
        public TcpClient Client { get; }
        public string Endpoint { get; }

        public ClientConnection(TcpClient client, string endpoint)
        {
            Client = client;
            Endpoint = endpoint;
        }

        public void Dispose()
        {
            try
            {
                Client?.Close();
                Client?.Dispose();
            }
            catch
            {
                // Ignore disposal errors
            }
        }
    }
}
