namespace RRUHFReaderService.Models;

public class Tag
{
    public int Id { get; set; }
    public string Epc { get; set; } = string.Empty;
    public string? Tid { get; set; }
    public string? UserMemory { get; set; }
    public DateTime FirstSeenAt { get; set; }
    public DateTime LastSeenAt { get; set; }
    public int TotalReadCount { get; set; }
    
    public int ReaderId { get; set; }
    public Reader Reader { get; set; } = null!;
    
    public ICollection<TagTransaction> Transactions { get; set; } = new List<TagTransaction>();
}
