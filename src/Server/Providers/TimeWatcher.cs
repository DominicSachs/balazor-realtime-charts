namespace BalazorRealtimeCharts.Server.Providers;

public sealed class TimeWatcher
{
    private Action? _executor;
    private AutoResetEvent? _autoResetEvent;
    private Timer? _timer;
    private DateTime _watcherStarted;

    public bool IsWatcherStarted { get; private set; }

    public void Watcher(Action execute)
    {
        int callBackDelayBeforeInvokeCallback = 1000;
        int timeIntervalBetweenInvokeCallback = 2000;

        _executor = execute;
        _autoResetEvent = new AutoResetEvent(false);

        _timer = new Timer((object? obj) =>
        {
            _executor();

            if ((DateTime.Now - _watcherStarted).TotalSeconds > 31160)
            {
                IsWatcherStarted = false;
                _timer!.Dispose();
            }

        }, _autoResetEvent, callBackDelayBeforeInvokeCallback, timeIntervalBetweenInvokeCallback);

        _watcherStarted = DateTime.Now;
        IsWatcherStarted = true;
    }

}
