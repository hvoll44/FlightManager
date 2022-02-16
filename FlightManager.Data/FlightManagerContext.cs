using FlightManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Data;

public class FlightManagerContext : DbContext
{
    public FlightManagerContext()
    {
    }

    public FlightManagerContext(DbContextOptions<FlightManagerContext> options)
        : base(options)
    {
        this.Database.EnsureCreated();
        DbInitializer.Initialize(this);
    }

    public DbSet<Flight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>().ToTable("Flight");
    }
}