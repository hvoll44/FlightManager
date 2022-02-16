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

        var flights = new Flight[]
        {
            new Flight{Origin = "DEN", Destination = "LAX"},
            new Flight{Origin = "ORD", Destination = "JFK"},
        };

        context.Flights.AddRange(flights);
        context.SaveChanges();
    }
}