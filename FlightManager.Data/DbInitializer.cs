using FlightManager.Data.Models;

namespace FlightManager.Data;

public static class DbInitializer
{
    public static void Initialize(FlightManagerContext context)
    {
        //Look for any flights
        if (context.Flights.Any())
        {
            return; // DB has been seeded
        }

        var airports = new Airport[]
        {
            new Airport { AirportCode = "DEN", Notes = "Clear sky and sun."},
            new Airport { AirportCode = "LAX", Notes = "Rain."},
            new Airport { AirportCode = "ORD", Notes = "Clear sky."},
            new Airport { AirportCode = "JFK", Notes = "Clear sky."},
            new Airport { AirportCode = "ATL", Notes = "Clear sky."},
            new Airport { AirportCode = "ORF", Notes = "Clear sky."},
            new Airport { AirportCode = "RIC", Notes = "Partly sunny."},
            new Airport { AirportCode = "IAH", Notes = "Partly sunny."},
            new Airport { AirportCode = "SFO", Notes = "Partly sunny."},
        };

        context.Airports.AddRange(airports);
        context.SaveChanges();

        var flights = new Flight[]
        {
            new Flight{OriginAirportID = 1, DestinationAirportID = 2, Departure = DateTime.Now, Arrival = DateTime.Now.AddHours(3)},
            new Flight{OriginAirportID = 1, DestinationAirportID = 2, Departure = DateTime.Now, Arrival = DateTime.Now.AddHours(3)},
            new Flight{OriginAirportID = 1, DestinationAirportID = 2, Departure = DateTime.Now, Arrival = DateTime.Now.AddHours(3)},
            new Flight{OriginAirportID = 1, DestinationAirportID = 2, Departure = DateTime.Now, Arrival = DateTime.Now.AddHours(3)},
            new Flight{OriginAirportID = 1, DestinationAirportID = 2, Departure = DateTime.Now, Arrival = DateTime.Now.AddHours(3)},
            new Flight{OriginAirportID = 1, DestinationAirportID = 2, Departure = DateTime.Now, Arrival = DateTime.Now.AddHours(3)},
        };

        context.Flights.AddRange(flights);
        context.SaveChanges();
    }
}