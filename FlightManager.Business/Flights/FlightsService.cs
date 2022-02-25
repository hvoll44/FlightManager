using FlightManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightManager.Business.Flights;

public interface IFlightsService
{
    public Task<List<FlightViewModel>> GetFlightsAsync();
    public Task<FlightViewModel> GetFlightByIdAsync(int id);
}

public class FlightsService : IFlightsService
{
    private readonly IDbContextFactory<FlightManagerContext> _db;

    public FlightsService(IDbContextFactory<FlightManagerContext> db)
    {
        _db = db;
    }

    public async Task<List<FlightViewModel>> GetFlightsAsync()
    {
        using var context = _db.CreateDbContext();

        return context.Flights
            .Include(f => f.Origin)
            .Include(f => f.Destination)
            .Select(f => f.ToModel())
            .ToList();
    }

    public async Task<FlightViewModel> GetFlightByIdAsync(int id)
    {
        using var context = _db.CreateDbContext();

        return context.Flights
            .First(f => f.FlightID == id)
            .ToModel();
    }
}