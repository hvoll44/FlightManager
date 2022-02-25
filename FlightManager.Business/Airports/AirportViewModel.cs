using FlightManager.Business.Flights;
using FlightManager.Data.Models;

namespace FlightManager.Business.Airports;

public class AirportViewModel
{
    public string AirportCode { get; set; } = string.Empty;

    public string Notes { get; set; } = String.Empty;

    public List<FlightViewModel> Departures { get; set; } = new();

    public List<FlightViewModel> Arrivals { get; set; } = new();
}

public static class AirportViewModelMappers
{
    public static AirportViewModel ToModel(this Airport model) => new()
    {
        AirportCode = model.AirportCode,
        Notes = model.Notes,
        Departures = model.Departures.Select(d => d.ToModel()).ToList(),
        Arrivals = model.Arrivals.Select(d => d.ToModel()).ToList(),
    };
}