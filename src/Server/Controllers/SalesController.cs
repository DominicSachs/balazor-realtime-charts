using BalazorRealtimeCharts.Server;
using BalazorRealtimeCharts.Server.Hubs;
using BalazorRealtimeCharts.Server.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace balazor_realtime_charts.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController : ControllerBase
{
    private IHubContext<ChartHub> _chartHub;
    private readonly TimeWatcher _watcher;

    public SalesController(IHubContext<ChartHub> chartHub, TimeWatcher watcher)
    {
        _chartHub = chartHub;
        _watcher = watcher;
    }

    [HttpGet]
    public IActionResult Get()
    {
        if (!_watcher.IsWatcherStarted)
        {
            _watcher.Watcher(() => _chartHub.Clients.All.SendAsync(Constants.Hubs.SendSalesDataMethodName, MealDataProvider.GetMealItems()));
        }

        return Ok();
    }
}