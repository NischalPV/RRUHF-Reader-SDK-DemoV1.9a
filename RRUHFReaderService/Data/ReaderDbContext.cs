using Microsoft.EntityFrameworkCore;
using RRUHFReaderService.Models;

namespace RRUHFReaderService.Data;

public class ReaderDbContext : DbContext
{
    public ReaderDbContext(DbContextOptions<ReaderDbContext> options) : base(options)
    {
    }

    public DbSet<Reader> Readers => Set<Reader>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<TagTransaction> TagTransactions => Set<TagTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.DeviceId).IsUnique();
            entity.Property(e => e.IpAddress).HasMaxLength(50);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Epc, e.ReaderId }).IsUnique();
            entity.Property(e => e.Epc).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Tid).HasMaxLength(100);
            entity.Property(e => e.UserMemory).HasMaxLength(500);
            
            entity.HasOne(e => e.Reader)
                .WithMany(r => r.Tags)
                .HasForeignKey(e => e.ReaderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TagTransaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.DetectedAt);
            entity.Property(e => e.ReaderTimestamp).HasMaxLength(50);
            entity.Property(e => e.RawData).HasMaxLength(1000);
            
            entity.HasOne(e => e.Tag)
                .WithMany(t => t.Transactions)
                .HasForeignKey(e => e.TagId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Reader)
                .WithMany()
                .HasForeignKey(e => e.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
