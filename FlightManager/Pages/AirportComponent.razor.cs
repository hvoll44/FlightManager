using FlightManager.Business.Airports;
using Microsoft.AspNetCore.Components;

namespace FlightManager.Pages;

public sealed partial class AirportComponent
{
    private bool _loading;
    private List<AirportViewModel> _airports = new();

    [Inject]
    public IAirportsService? AirportsService { get; set; }

    protected override void OnInitialized()
    {
        _loading = true;
        _airports = AirportsService!.GetAirportsAsync().Result;
        _loading = false;

        base.OnInitialized();
    }
}