using FlightManager.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Business.Airports;

public interface IAirportsService
{
    Task<AirportViewModel> GetAirportByCodeAsync(string airportCode);
    Task<List<AirportViewModel>> GetAirportsAsync();
}

public class AirportsService : IAirportsService
{
    private readonly IDbContextFactory<FlightManagerContext> _db;

    public AirportsService(IDbContextFactory<FlightManagerContext> db)
    {
        _db = db;
    }

    public async Task<List<AirportViewModel>> GetAirportsAsync()
    {
        using var context = _db.CreateDbContext();

        return context.Airports
            .Include(a => a.Departures)
            .Include(a => a.Arrivals)
            .ToList().Select(a => a.ToModel()).ToList();
    }

    public async Task<AirportViewModel> GetAirportByCodeAsync(string airportCode)
    {
        using var context = _db.CreateDbContext();

        return context.Airports
            .Include(a => a.Departures)
            .Include(a => a.Arrivals)
            .First(a => a.AirportCode == airportCode)
            .ToModel();
    }
}