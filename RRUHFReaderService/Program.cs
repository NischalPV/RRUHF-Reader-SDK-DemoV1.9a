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

// Ensure database is created
using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ReaderDbContext>();
    dbContext.Database.EnsureCreated();
}

host.Run();
