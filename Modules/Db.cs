using Microsoft.EntityFrameworkCore;
using telecom.Modules.Customer.Models;

namespace telecom.Modules.Telecom.Data;

public class TelecomContext : DbContext
{
    public TelecomContext(DbContextOptions<TelecomContext> options) : base(options)
    {
    }

    public DbSet<package> package => Set<package>();
    public DbSet<customer> customer => Set<customer>();
    public DbSet<register_package> register_package => Set<register_package>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("telecom");
        modelBuilder.Entity<package>(entity =>
        {
            entity.HasKey(e => e.package_uid);
            entity.Property(e => e.package_name)
                .HasMaxLength(255);
        });
        modelBuilder.Entity<customer>(entity =>
        {
            entity.HasKey(e => e.customer_uid);
        });
        modelBuilder.Entity<register_package>(entity =>
        {
            entity.HasKey(e => e.register_package_uid);
        });
    }
}