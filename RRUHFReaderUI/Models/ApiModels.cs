namespace RRUHFReaderUI.Models;

public record ReaderDto(
    int Id,
    uint DeviceId,
    string? IpAddress,
    int Port,
    DateTime FirstSeenAt,
    DateTime LastSeenAt,
    bool IsActive);

public record TagDto(
    int Id,
    string Epc,
    string? Tid,
    string? UserMemory,
    DateTime FirstSeenAt,
    DateTime LastSeenAt,
    int TotalReadCount,
    int ReaderId);

public record TagTransactionDto(
    int Id,
    DateTime DetectedAt,
    double? Rssi,
    byte? AntennaId,
    string? ReaderTimestamp,
    int TagId,
    int ReaderId,
    string TagEpc);

public record CommandRequest(string ReaderAddress, int Port = 8888);
public record CommandResponse(bool Success, string Message);

public record StatsSummary(
    int TotalReaders,
    int ActiveReaders,
    int TotalTags,
    int TotalTransactions,
    int RecentTransactions);
