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
    
    public DbSet<Airport> Airports { get; set; }

    public DbSet<Aircraft> Aircrafts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.ToTable("Flight");

            entity.HasOne(flight => flight.Origin).WithMany(airport => airport.Departures).HasForeignKey(flight => flight.OriginAirportID);
            
            entity.HasOne(flight => flight.Destination).WithMany(airport => airport.Arrivals).HasForeignKey(flight => flight.DestinationAirportID);

            entity.HasOne(flight => flight.Aircraft).WithMany(aircraft => aircraft.Flights).HasForeignKey(flight => flight.AircraftID);
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.ToTable("Airport");

            entity.HasMany(airport => airport.Departures).WithOne(flight => flight.Origin);
            
            entity.HasMany(airport => airport.Arrivals).WithOne(flight => flight.Destination);
        });

        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.ToTable("Aircraft");

            entity.HasMany(aircraft => aircraft.Flights).WithOne(flight => flight.Aircraft);
        });
    }
}