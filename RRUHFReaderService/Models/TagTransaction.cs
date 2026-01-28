namespace RRUHFReaderService.Models;

public class TagTransaction
{
    public int Id { get; set; }
    public DateTime DetectedAt { get; set; }
    public double? Rssi { get; set; }
    public byte? AntennaId { get; set; }
    public string? ReaderTimestamp { get; set; }
    public string? RawData { get; set; }
    
    public int TagId { get; set; }
    public Tag Tag { get; set; } = null!;
    
    public int ReaderId { get; set; }
    public Reader Reader { get; set; } = null!;
}
