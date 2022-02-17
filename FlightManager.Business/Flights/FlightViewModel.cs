using FlightManager.Data.Models;

namespace FlightManager.Business.Flights;

public class FlightViewModel
{
    public int FlightID { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
}

public static class FlightViewModelMappers
{
    public static Flight ToDto(this FlightViewModel model) => new Flight()
    {
        FlightID = model.FlightID,
        Origin = model.Origin,
        Destination = model.Destination
    };
    
    public static FlightViewModel ToModel(this Flight model) => new FlightViewModel()
    {
        FlightID = model.FlightID,
        Origin = model.Origin,
        Destination = model.Destination
    };
}