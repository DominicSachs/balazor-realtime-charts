using BalazorRealtimeCharts.Client.Models;
using BalazorRealtimeCharts.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BalazorRealtimeCharts.Client.Pages;

public partial class Index : IAsyncDisposable
{
    private HubConnection? _hubConnection;
    public List<ChartLine> Data = new();
    public Dictionary<string, List<ChartLine>> CategoryData = new();

    [Inject]
    public HttpClient? HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await InitHubConnection();
        await HttpClient!.GetAsync("sales");
        ListenForData();
    }

    private async Task InitHubConnection()
    {
        _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7114/chartdata").WithAutomaticReconnect().Build();
        await _hubConnection.StartAsync();
    }

    private void ListenForData()
    {
        _hubConnection!.On<List<MealItem>>("SendSalesData", (data) =>
        {
            var groups = data.GroupBy(g => g.Category).OrderBy(o => o.Key);
            Data = groups.Select(s => new ChartLine(s.Key.ToString(), s.Sum(i => i.Count))).ToList();
            CategoryData = groups.ToDictionary(g => g.Key.ToString(), g => g.Select(p => new ChartLine(p.Name, p.Count)).ToList());
            StateHasChanged();
        });
    }

    public async ValueTask DisposeAsync()
    {
        await _hubConnection!.DisposeAsync();
    }
}