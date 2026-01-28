using System.Collections.Concurrent;
using System.Net.Sockets;

namespace RRUHFReaderAPI.Services;

public class ReaderConnectionService
{
    private readonly ConcurrentDictionary<string, TcpClient> _connections = new();
    private readonly ILogger<ReaderConnectionService> _logger;

    public ReaderConnectionService(ILogger<ReaderConnectionService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> ConnectToReaderAsync(string readerAddress, int port = 8888)
    {
        var key = $"{readerAddress}:{port}";
        
        if (_connections.ContainsKey(key))
        {
            _logger.LogInformation("Already connected to {Key}", key);
            return true;
        }

        try
        {
            var client = new TcpClient();
            await client.ConnectAsync(readerAddress, port);
            _connections[key] = client;
            _logger.LogInformation("Connected to reader at {Key}", key);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to connect to reader at {Key}", key);
            return false;
        }
    }

    public async Task<bool> SendCommandAsync(string readerAddress, int port, byte[] command)
    {
        var key = $"{readerAddress}:{port}";
        
        if (!_connections.TryGetValue(key, out var client) || !client.Connected)
        {
            _logger.LogWarning("Not connected to {Key}, attempting to connect", key);
            if (!await ConnectToReaderAsync(readerAddress, port))
            {
                return false;
            }
            client = _connections[key];
        }

        try
        {
            var stream = client.GetStream();
            await stream.WriteAsync(command, 0, command.Length);
            _logger.LogInformation("Sent command ({Bytes} bytes) to {Key}", command.Length, key);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send command to {Key}", key);
            _connections.TryRemove(key, out _);
            client?.Dispose();
            return false;
        }
    }

    public void DisconnectAll()
    {
        foreach (var connection in _connections.Values)
        {
            try
            {
                connection.Close();
                connection.Dispose();
            }
            catch { }
        }
        _connections.Clear();
        _logger.LogInformation("Disconnected all readers");
    }

    public IEnumerable<string> GetConnectedReaders()
    {
        return _connections.Keys.Where(k => _connections[k].Connected);
    }
}
