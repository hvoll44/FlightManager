using FlightManager.Business.Airports;
using Microsoft.AspNetCore.Components;

namespace FlightManager.Pages;

public sealed partial class AirportDetailsComponent
{
    private bool _loading;
    private AirportViewModel _airport = new();

    [Parameter]
    public string AirportCode { get; set; } = string.Empty;

    [Inject]
    public IAirportsService? AirportsService { get; set; }

    protected override void OnParametersSet()
    {
        _loading = true;
        _airport = AirportsService!.GetAirportByCodeAsync(AirportCode).Result;
        _loading = false;

        base.OnInitialized();
    }
}