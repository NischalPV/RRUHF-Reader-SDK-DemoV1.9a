# RRUHF Reader Service

A .NET 10 background service that listens to RFID UHF readers over TCP/IP, decodes the binary protocol data, and stores tag information in a SQLite database.

## Features

- **TCP/IP Listener**: Accepts connections from multiple RFID readers simultaneously
- **Protocol Decoder**: Parses the RRUHFR03 binary protocol (0xBB frame format with CRC16 validation)
- **Automatic Data Translation**: Decodes inventory responses and extracts:
  - Reader information (Device ID, IP address)
  - Tag data (EPC, TID, User Memory)
  - Transaction details (RSSI, Antenna ID, Timestamp)
- **SQLite Database**: Stores data in three normalized tables:
  - `Readers`: Reader device information
  - `Tags`: Unique tag identifiers
  - `TagTransactions`: Individual tag detection events

## Database Schema

### Readers Table
- `Id` (Primary Key)
- `DeviceId` (Unique, UInt32)
- `IpAddress`
- `Port`
- `FirstSeenAt`
- `LastSeenAt`
- `IsActive`

### Tags Table
- `Id` (Primary Key)
- `Epc` (Electronic Product Code - Required)
- `Tid` (Tag ID Bank - Optional)
- `UserMemory` (Optional)
- `ReaderId` (Foreign Key)
- `FirstSeenAt`
- `LastSeenAt`
- `TotalReadCount`

### TagTransactions Table
- `Id` (Primary Key)
- `TagId` (Foreign Key)
- `ReaderId` (Foreign Key)
- `DetectedAt`
- `Rssi` (Signal Strength in dBm)
- `AntennaId`
- `ReaderTimestamp`
- `RawData` (Hex string of original frame)

## Configuration

Edit `appsettings.json` to configure the service:

```json
{
  "TcpListener": {
    "Host": "0.0.0.0",  // Listen on all interfaces
    "Port": 8888         // TCP port for reader connections
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=rfid_reader.db"
  }
}
```

## Running the Service

### Development
```bash
cd RRUHFReaderService
dotnet run
```

### Production (as a Windows Service)
```bash
dotnet publish -c Release -r win-x64 --self-contained
sc create RRUHFReaderService binPath="C:\path\to\RRUHFReaderService.exe"
sc start RRUHFReaderService
```

### Production (as a Linux systemd service)
```bash
dotnet publish -c Release -r linux-x64 --self-contained
sudo nano /etc/systemd/system/rruhf-reader.service
```

Add the following content:
```ini
[Unit]
Description=RRUHF Reader Service
After=network.target

[Service]
Type=notify
ExecStart=/path/to/RRUHFReaderService
WorkingDirectory=/path/to/
Restart=always
RestartSec=10

[Install]
WantedBy=multi-user.target
```

Then enable and start:
```bash
sudo systemctl daemon-reload
sudo systemctl enable rruhf-reader.service
sudo systemctl start rruhf-reader.service
```

## Protocol Details

The service implements the RRUHFR03 communication protocol:

- **Frame Format**: `0xBB [Length] [Command] [Data...] [CRC-High] [CRC-Low]`
- **Start of Frame (SOF)**: `0xBB`
- **CRC**: CRC16-CCITT validation
- **Inventory Response**: Command code `0xE0`

### Supported Response Fields
- Device ID (32-bit reader serial number)
- Timestamp (6-byte format)
- Antenna ID
- EPC/UID (Electronic Product Code)
- TID (Tag ID Bank)
- User Memory
- RSSI (Received Signal Strength Indicator in dBm)

## Architecture

```
┌─────────────────┐
│  RFID Readers   │
│  (TCP Clients)  │
└────────┬────────┘
         │ TCP/IP (Port 8888)
         ▼
┌─────────────────────────────┐
│ TcpReaderListenerService    │
│  - Accept connections       │
│  - Receive binary data      │
└────────┬────────────────────┘
         │
         ▼
┌─────────────────────────────┐
│ FrameParser                 │
│  - Parse 0xBB frames        │
│  - Validate CRC16           │
│  - Decode inventory data    │
└────────┬────────────────────┘
         │
         ▼
┌─────────────────────────────┐
│ ReaderDbContext (EF Core)   │
│  - Store readers            │
│  - Store tags               │
│  - Store transactions       │
└────────┬────────────────────┘
         │
         ▼
┌─────────────────────────────┐
│ SQLite Database             │
│  (rfid_reader.db)           │
└─────────────────────────────┘
```

## Querying the Database

You can query the database using any SQLite client or directly with Entity Framework:

```bash
# Install sqlite3 command-line tool
sqlite3 rfid_reader.db

# List all readers
SELECT * FROM Readers;

# List all tags
SELECT * FROM Tags;

# Get recent transactions with tag and reader info
SELECT 
    t.DetectedAt,
    tg.Epc,
    tg.Tid,
    t.Rssi,
    t.AntennaId,
    r.DeviceId,
    r.IpAddress
FROM TagTransactions t
JOIN Tags tg ON t.TagId = tg.Id
JOIN Readers r ON t.ReaderId = r.Id
ORDER BY t.DetectedAt DESC
LIMIT 100;
```

## Logging

The service uses Microsoft.Extensions.Logging for comprehensive logging:

- **Information**: Service lifecycle, new readers/tags detected
- **Debug**: Raw data received, packet details
- **Warning**: Protocol issues, missing data
- **Error**: Connection failures, database errors

Logs are output to the console by default. Configure additional log providers in `appsettings.json`.

## Dependencies

- .NET 10.0
- Microsoft.EntityFrameworkCore.Sqlite 10.0.x
- Microsoft.EntityFrameworkCore.Design 10.0.x
- Microsoft.Extensions.Hosting 10.0.x

## License

This project is part of the RRUHF Reader SDK Demo repository.
