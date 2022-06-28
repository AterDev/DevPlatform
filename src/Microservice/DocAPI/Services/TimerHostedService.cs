namespace DocAPI.Services;

public class TimerHostedService : IHostedService
{
    private readonly ILogger<TimerHostedService> _logger;
    private IServiceProvider Services { get; }
    private Timer? _timer = null;

    public TimerHostedService(IServiceProvider service, ILogger<TimerHostedService> logger)
    {
        Services = service;
        _logger = logger;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("🕓Start timer");
        _timer = new Timer(UpdateDocs, null, TimeSpan.FromHours(1),
         TimeSpan.FromHours(6));
        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();


    private async void UpdateDocs(object? data)
    {
        _logger.LogInformation(
            "更新文档");
        using var scope = Services.CreateScope();
        try
        {
            var syncSvc = scope.ServiceProvider.GetRequiredService<DocsSyncServices>();
            await syncSvc.AutoSyncAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message + ex.StackTrace);
        }

    }
}
