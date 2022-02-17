using FlightManager.Business.Flights;
using Microsoft.AspNetCore.Components;

namespace FlightManager.Pages;

public sealed partial class FlightComponent
{
    private List<FlightViewModel> flights = new();

    [Inject]
    public IFlightsService FlightsService { get; set; }

    protected override void OnInitialized()
    {
        flights = FlightsService.GetFlightsAsync().Result;

        base.OnInitialized();
    }
}