using Microsoft.EntityFrameworkCore;
using RRUHFReaderAPI.Commands;
using RRUHFReaderAPI.DTOs;
using RRUHFReaderAPI.Services;
using RRUHFReaderService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add database context
builder.Services.AddDbContext<ReaderDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? "../RRUHFReaderService/rfid_reader.db";
    options.UseSqlite($"Data Source={connectionString}");
});

// Add reader connection service
builder.Services.AddSingleton<ReaderConnectionService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();

// Command endpoints
app.MapPost("/api/commands/connect", async (CommandRequest req, ReaderConnectionService service) =>
{
    var success = await service.ConnectToReaderAsync(req.ReaderAddress, req.Port);
    return Results.Ok(new CommandResponse(success, success ? "Connected" : "Failed to connect"));
})
.WithName("ConnectToReader")
.WithTags("Commands");

app.MapPost("/api/commands/device-info", async (CommandRequest req, ReaderConnectionService service) =>
{
    var command = CommandBuilder.BuildGetDeviceInfoFrame();
    var success = await service.SendCommandAsync(req.ReaderAddress, req.Port, command);
    return Results.Ok(new CommandResponse(success, success ? "Command sent" : "Failed to send"));
})
.WithName("GetDeviceInfo")
.WithTags("Commands");

app.MapPost("/api/commands/inventory", async (CommandRequest req, ReaderConnectionService service) =>
{
    var command = CommandBuilder.BuildInventoryFrame();
    var success = await service.SendCommandAsync(req.ReaderAddress, req.Port, command);
    return Results.Ok(new CommandResponse(success, success ? "Inventory started" : "Failed to send"));
})
.WithName("StartInventory")
.WithTags("Commands");

app.MapPost("/api/commands/working-mode", async (SetWorkingModeRequest req, ReaderConnectionService service) =>
{
    var command = CommandBuilder.BuildSetWorkingModeFrame(req.WorkingMode);
    var success = await service.SendCommandAsync(req.ReaderAddress, req.Port, command);
    return Results.Ok(new CommandResponse(success, success ? "Working mode set" : "Failed to send"));
})
.WithName("SetWorkingMode")
.WithTags("Commands");

app.MapPost("/api/commands/rf-power", async (SetRFPowerRequest req, ReaderConnectionService service) =>
{
    var command = CommandBuilder.BuildSetRFPowerFrame(req.Power);
    var success = await service.SendCommandAsync(req.ReaderAddress, req.Port, command);
    return Results.Ok(new CommandResponse(success, success ? "RF power set" : "Failed to send"));
})
.WithName("SetRFPower")
.WithTags("Commands");

app.MapPost("/api/commands/region", async (SetRegionRequest req, ReaderConnectionService service) =>
{
    var command = CommandBuilder.BuildSetRegionFrame(req.Region);
    var success = await service.SendCommandAsync(req.ReaderAddress, req.Port, command);
    return Results.Ok(new CommandResponse(success, success ? "Region set" : "Failed to send"));
})
.WithName("SetRegion")
.WithTags("Commands");

app.MapPost("/api/commands/restart", async (CommandRequest req, ReaderConnectionService service) =>
{
    var command = CommandBuilder.BuildRestartDeviceFrame();
    var success = await service.SendCommandAsync(req.ReaderAddress, req.Port, command);
    return Results.Ok(new CommandResponse(success, success ? "Restart command sent" : "Failed to send"));
})
.WithName("RestartDevice")
.WithTags("Commands");

// Query endpoints
app.MapGet("/api/readers", async (ReaderDbContext db) =>
{
    var readers = await db.Readers
        .Select(r => new ReaderDto(r.Id, r.DeviceId, r.IpAddress, r.Port, 
                                    r.FirstSeenAt, r.LastSeenAt, r.IsActive))
        .ToListAsync();
    return Results.Ok(readers);
})
.WithName("GetReaders")
.WithTags("Data");

app.MapGet("/api/readers/{id}", async (int id, ReaderDbContext db) =>
{
    var reader = await db.Readers.FindAsync(id);
    if (reader == null) return Results.NotFound();
    
    var dto = new ReaderDto(reader.Id, reader.DeviceId, reader.IpAddress, 
                           reader.Port, reader.FirstSeenAt, reader.LastSeenAt, reader.IsActive);
    return Results.Ok(dto);
})
.WithName("GetReaderById")
.WithTags("Data");

app.MapGet("/api/tags", async (ReaderDbContext db, int? readerId = null) =>
{
    var query = db.Tags.AsQueryable();
    
    if (readerId.HasValue)
        query = query.Where(t => t.ReaderId == readerId.Value);
    
    var tags = await query
        .Select(t => new TagDto(t.Id, t.Epc, t.Tid, t.UserMemory,
                               t.FirstSeenAt, t.LastSeenAt, t.TotalReadCount, t.ReaderId))
        .ToListAsync();
    
    return Results.Ok(tags);
})
.WithName("GetTags")
.WithTags("Data");

app.MapGet("/api/tags/{id}", async (int id, ReaderDbContext db) =>
{
    var tag = await db.Tags.FindAsync(id);
    if (tag == null) return Results.NotFound();
    
    var dto = new TagDto(tag.Id, tag.Epc, tag.Tid, tag.UserMemory,
                        tag.FirstSeenAt, tag.LastSeenAt, tag.TotalReadCount, tag.ReaderId);
    return Results.Ok(dto);
})
.WithName("GetTagById")
.WithTags("Data");

app.MapGet("/api/transactions", async (ReaderDbContext db, int? tagId = null, int? readerId = null, int limit = 100) =>
{
    var query = db.TagTransactions
        .Include(t => t.Tag)
        .AsQueryable();
    
    if (tagId.HasValue)
        query = query.Where(t => t.TagId == tagId.Value);
    
    if (readerId.HasValue)
        query = query.Where(t => t.ReaderId == readerId.Value);
    
    var transactions = await query
        .OrderByDescending(t => t.DetectedAt)
        .Take(limit)
        .Select(t => new TagTransactionDto(t.Id, t.DetectedAt, t.Rssi, t.AntennaId,
                                          t.ReaderTimestamp, t.TagId, t.ReaderId, t.Tag.Epc))
        .ToListAsync();
    
    return Results.Ok(transactions);
})
.WithName("GetTransactions")
.WithTags("Data");

app.MapGet("/api/stats/summary", async (ReaderDbContext db) =>
{
    var totalReaders = await db.Readers.CountAsync();
    var activeReaders = await db.Readers.CountAsync(r => r.IsActive);
    var totalTags = await db.Tags.CountAsync();
    var totalTransactions = await db.TagTransactions.CountAsync();
    var recentTransactions = await db.TagTransactions
        .Where(t => t.DetectedAt >= DateTime.UtcNow.AddHours(-1))
        .CountAsync();
    
    return Results.Ok(new
    {
        TotalReaders = totalReaders,
        ActiveReaders = activeReaders,
        TotalTags = totalTags,
        TotalTransactions = totalTransactions,
        RecentTransactions = recentTransactions
    });
})
.WithName("GetStatsSummary")
.WithTags("Data");

app.Run();
