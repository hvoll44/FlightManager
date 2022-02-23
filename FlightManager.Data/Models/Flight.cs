namespace FlightManager.Data.Models;

public class Flight
{
    public int FlightID { get; set; }
    
    public int OriginAirportID { get; set; }

    public int DestinationAirportID { get; set; }
    
    public DateTime Departure { get; set; }
    
    public DateTime Arrival { get; set; }
    
    
    public Airport Origin { get; set; } = new();
    
    public Airport Destination { get; set; } = new();
}