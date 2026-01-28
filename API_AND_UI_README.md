# RRUHF Reader API & UI

Complete solution for controlling RRUHFR03 RFID readers with Web API and Blazor UI.

## Components

### 1. RRUHFReaderAPI (Minimal API)
ASP.NET Core Minimal API providing REST endpoints for:
- **Command Endpoints**: Send commands to RFID readers (inventory, device info, etc.)
- **Data Endpoints**: Query database for readers, tags, and transactions
- **Statistics**: Get summary statistics

**Port**: 5000 (HTTP), 5001 (HTTPS)

### 2. RRUHFReaderUI (Blazor Server)
Interactive web UI for:
- Sending commands to readers
- Viewing real-time data
- Monitoring statistics
- Managing multiple readers

**Port**: 5002 (HTTP), 5003 (HTTPS)

### 3. RRUHFReaderService (Background Service)
TCP listener that receives data from readers and stores in SQLite database.

**Port**: 8888 (TCP)

## Quick Start

### 1. Start the Background Service (Terminal 1)
```bash
cd RRUHFReaderService
dotnet run
```
This starts the TCP listener on port 8888.

### 2. Start the API (Terminal 2)
```bash
cd RRUHFReaderAPI
dotnet run --urls "http://localhost:5000"
```

### 3. Start the Blazor UI (Terminal 3)
```bash
cd RRUHFReaderUI
dotnet run --urls "http://localhost:5002"
```

### 4. Open the UI
Navigate to: http://localhost:5002

## Architecture

```
┌─────────────────────┐
│   Blazor UI         │  Port 5002
│   (User Interface)  │
└──────────┬──────────┘
           │ HTTP
           ▼
┌─────────────────────┐
│   Minimal API       │  Port 5000
│   (REST API)        │
└──────────┬──────────┘
           │
           ├─ TCP ────────┐
           │              ▼
           │      ┌───────────────┐
           │      │ RFID Readers  │  Port 8888
           │      │ (TCP Clients) │
           │      └───────┬───────┘
           │              │
           │              ▼
           │      ┌───────────────┐
           │      │ Background    │
           │      │ Service       │
           │      │ (Listener)    │
           │      └───────┬───────┘
           │              │
           ▼              ▼
    ┌─────────────────────────┐
    │   SQLite Database       │
    │   (rfid_reader.db)      │
    └─────────────────────────┘
```

## API Endpoints

### Commands
- `POST /api/commands/connect` - Connect to reader
- `POST /api/commands/inventory` - Start inventory
- `POST /api/commands/device-info` - Get device information
- `POST /api/commands/working-mode` - Set working mode
- `POST /api/commands/rf-power` - Set RF power
- `POST /api/commands/region` - Set region
- `POST /api/commands/restart` - Restart device

### Data
- `GET /api/readers` - List all readers
- `GET /api/readers/{id}` - Get reader by ID
- `GET /api/tags` - List all tags
- `GET /api/tags/{id}` - Get tag by ID
- `GET /api/transactions` - List transactions
- `GET /api/stats/summary` - Get statistics summary

## Configuration

### API (appsettings.json)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "../RRUHFReaderService/rfid_reader.db"
  }
}
```

### UI (appsettings.json)
```json
{
  "ApiBaseUrl": "http://localhost:5000"
}
```

## Usage Example

1. **Connect to a Reader**:
   - Go to Commands page
   - Enter reader IP address (e.g., 192.168.1.100)
   - Click "Connect to Reader"

2. **Start Inventory**:
   - Click "Start Inventory"
   - The reader will start detecting tags
   - Data is stored in the database automatically

3. **View Data**:
   - Go to Readers page to see connected readers
   - Go to Tags page to see detected tags
   - Go to Transactions page to see detection events

## Command Request Examples

### Using curl

**Connect to Reader:**
```bash
curl -X POST http://localhost:5000/api/commands/connect \
  -H "Content-Type: application/json" \
  -d '{"readerAddress": "192.168.1.100", "port": 8888}'
```

**Start Inventory:**
```bash
curl -X POST http://localhost:5000/api/commands/inventory \
  -H "Content-Type: application/json" \
  -d '{"readerAddress": "192.168.1.100", "port": 8888}'
```

**Get Device Info:**
```bash
curl -X POST http://localhost:5000/api/commands/device-info \
  -H "Content-Type: application/json" \
  -d '{"readerAddress": "192.168.1.100", "port": 8888}'
```

**Get Readers:**
```bash
curl http://localhost:5000/api/readers
```

**Get Tags:**
```bash
curl http://localhost:5000/api/tags
```

**Get Statistics:**
```bash
curl http://localhost:5000/api/stats/summary
```

## Blazor UI Features

### Home Page
- Dashboard with statistics
- Quick action buttons
- System overview

### Commands Page
- Interactive form for reader connection
- Command buttons for inventory, device info
- Real-time command log

### Readers Page
- Table of all readers
- Status indicators (Active/Inactive)
- Connection details

### Tags Page
- List of all detected tags
- EPC, TID, and read count
- First/last seen timestamps

### Transactions Page
- Real-time transaction log
- RSSI values, antenna IDs
- Filterable and sortable

## Development

### Build All Projects
```bash
dotnet build
```

### Run Tests (if any)
```bash
dotnet test
```

### Publish for Production
```bash
cd RRUHFReaderAPI
dotnet publish -c Release -o ./publish

cd ../RRUHFReaderUI
dotnet publish -c Release -o ./publish
```

## Dependencies

- .NET 10.0
- ASP.NET Core
- Entity Framework Core
- SQLite
- Blazor Server

## Notes

- The API and UI must be able to access the SQLite database file
- Make sure the background service is running before sending commands
- The reader must be configured to send data to the background service port (8888)
- CORS is enabled for development; configure appropriately for production

## Troubleshooting

**API can't connect to reader:**
- Verify reader IP address and port
- Check network connectivity
- Ensure background service is running

**UI shows no data:**
- Verify API is running (http://localhost:5000)
- Check API URL in appsettings.json
- Ensure database file exists and is accessible

**Database errors:**
- Check file path in API appsettings.json
- Verify database file permissions
- Ensure background service created the database

## Security Notes

- This is a development configuration
- For production:
  - Enable HTTPS
  - Configure proper CORS policies
  - Add authentication/authorization
  - Secure database connection strings
  - Use environment variables for sensitive data
