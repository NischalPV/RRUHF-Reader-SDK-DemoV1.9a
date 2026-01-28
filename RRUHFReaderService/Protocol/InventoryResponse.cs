namespace RRUHFReaderService.Protocol;

public class InventoryResponse
{
    public uint DeviceId { get; set; }
    public string? Timestamp { get; set; }
    public byte? AntennaId { get; set; }
    public string Epc { get; set; } = string.Empty;
    public string? Tid { get; set; }
    public string? UserMemory { get; set; }
    public double? Rssi { get; set; }
    public byte[] RawData { get; set; } = Array.Empty<byte>();
}
