using FlightManager.Data.Models;

namespace FlightManager.Business.Flights;

public class FlightViewModel
{
    public int FlightID { get; set; }

    public DateTime Departure { get; set; }

    public DateTime Arrival { get; set; }

    public string Origin { get; set; }
    
    public string Destination { get; set; }
    
    public string OriginNotes { get; set; }
    
    public string DestinationNotes { get; set; }
}

public static class FlightViewModelMappers
{
    //public static Flight ToDto(this FlightViewModel model) => new Flight()
    //{
    //    FlightID = model.FlightID,
    //    Origin = model.Origin,
    //    Destination = model.Destination
    //};
    
    public static FlightViewModel ToModel(this Flight model) => new()
    {
        FlightID = model.FlightID,
        Origin = model.Origin.AirportCode,
        Destination = model.Destination.AirportCode,
        OriginNotes = model.Origin.Notes,
        DestinationNotes = model.Destination.Notes,
        Departure = model.Departure,
        Arrival = model.Arrival,
    };
}