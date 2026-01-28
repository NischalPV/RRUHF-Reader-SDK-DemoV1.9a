namespace RRUHFReaderService.Models;

public class Reader
{
    public int Id { get; set; }
    public uint DeviceId { get; set; }
    public string? IpAddress { get; set; }
    public int Port { get; set; }
    public DateTime FirstSeenAt { get; set; }
    public DateTime LastSeenAt { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
