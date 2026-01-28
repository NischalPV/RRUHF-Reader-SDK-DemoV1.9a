namespace RRUHFReaderService.Protocol;

public static class Helpers
{
    public static string ByteArrayToHex(byte[] bytes)
    {
        return BitConverter.ToString(bytes).Replace("-", "");
    }

    public static string TimeStampStr(byte[] timestamp)
    {
        if (timestamp == null || timestamp.Length < 6)
            return string.Empty;

        try
        {
            int year = timestamp[0] + 2000;
            int month = timestamp[1];
            int day = timestamp[2];
            int hour = timestamp[3];
            int minute = timestamp[4];
            int second = timestamp[5];

            return $"{year:D4}-{month:D2}-{day:D2} {hour:D2}:{minute:D2}:{second:D2}";
        }
        catch
        {
            return ByteArrayToHex(timestamp);
        }
    }
}
