namespace FlightManager.Data.Models;
public class Aircraft
{
    public int AircraftID { get; set; }

    public string Make { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int YearBuilt { get; set; }

    public string SerialNumber { get; set; } = string.Empty;

    public List<Flight> Flights { get; set; } = new();
}