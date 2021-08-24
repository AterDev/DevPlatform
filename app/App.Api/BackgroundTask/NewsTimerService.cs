
using Services.NewsCollectionService;

namespace App.Api.BackgroundTask;
public class NewsTimerService : IHostedService, IDisposable
{
    private int executionCount = 0;
    private readonly ILogger<NewsTimerService> _logger;
    private Timer _timer;

    public NewsTimerService(ILogger<NewsTimerService> logger, IServiceProvider services)
    {
        Services = services;
        _logger = logger;
    }

    public IServiceProvider Services { get; }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("News collection service start.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromHours(4));
        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using var scope = Services.CreateScope();
        var newsService = scope.ServiceProvider.GetRequiredService<NewsCollectionService>();
        newsService.Start();
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
