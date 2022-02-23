namespace FlightManager.Data.Models;

public class Airport
{
    public int AirportID { get; set; }
    
    public string AirportCode { get; set; } = string.Empty;
    
    public string Notes { get; set; } = String.Empty;

    public List<Flight> Departures { get; set; } = new();

    public List<Flight> Arrivals { get; set; } = new();
}