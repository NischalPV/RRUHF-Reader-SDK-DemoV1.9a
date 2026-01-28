using Microsoft.EntityFrameworkCore;
using RRUHFReaderService.Data;
using RRUHFReaderService.Services;

var builder = Host.CreateApplicationBuilder(args);

// Add database context
builder.Services.AddDbContext<ReaderDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString);
});

// Add background services
builder.Services.AddHostedService<TcpReaderListenerService>();

var host = builder.Build();

// Ensure database is created and migrated
using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ReaderDbContext>();
    // For production, use migrations. For demo/development, EnsureCreated is acceptable.
    dbContext.Database.EnsureCreated();
}

host.Run();
