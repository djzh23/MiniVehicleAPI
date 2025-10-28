using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(b =>
        {

            b.Property(x => x.Make).IsRequired().HasMaxLength(60);
            b.Property(x => x.Model).IsRequired().HasMaxLength(60);
            b.Property(x => x.Year).IsRequired();
            b.Property(x => x.Price).HasColumnType("decimal(18,2)");
            b.HasIndex(x => x.Vin).IsUnique();

        });
    }
}