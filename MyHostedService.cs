public sealed class MyHostedService : IHostedService, IHostedLifecycleService
{
    private readonly ILogger _logger;

    public MyHostedService(
        ILogger<MyHostedService> logger,
        IHostApplicationLifetime appLifetime
    )
    {
        _logger = logger;
        appLifetime.ApplicationStarted.Register(OnStarted);
        appLifetime.ApplicationStopping.Register(OnStopping);
        appLifetime.ApplicationStopped.Register(OnStopped);
    }


    Task IHostedLifecycleService.StartingAsync(System.Threading.CancellationToken cancellationToken)
    {
        _logger.LogInformation("1. StartingAsync has been called");

        return Task.CompletedTask;
    }


    Task IHostedService.StartAsync(System.Threading.CancellationToken cancellationToken)
    {
        _logger.LogInformation("2. StartAsync has been called");

        return Task.CompletedTask;
    }


    Task IHostedLifecycleService.StartedAsync(System.Threading.CancellationToken cancellationToken)
    {
        _logger.LogInformation("3. StartedAsync has been called");

        return Task.CompletedTask;
    }

    private void OnStarted()
    {
        _logger.LogInformation("4. OnStarted has been called");
    }

    private void OnStopping()
    {
        _logger.LogInformation("5. OnStopping has been called");
    }


    Task IHostedLifecycleService.StoppingAsync(System.Threading.CancellationToken cancellationToken)
    {
        _logger.LogInformation("5. Stopping Async has been called");

        return Task.CompletedTask;
    }

    Task IHostedService.StopAsync(System.Threading.CancellationToken cancellationToken)
    {
        _logger.LogInformation("6. StopAsync has been called");

        return CreateDelay(cancellationToken);
    }

    Task IHostedLifecycleService.StoppedAsync(System.Threading.CancellationToken cancellationToken)
    {
        _logger.LogInformation("7. StoppedAsync has been called.");

        return Task.CompletedTask;
    }

    private async void OnStopped()
    {
        _logger.LogInformation("9. OnStopped has been called");

    }

    private async Task CreateDelay(CancellationToken cancellationToken) 
    {
        _logger.LogInformation("Starting delay");
        await Task.Delay(5000, cancellationToken);
        _logger.LogInformation("Completed delay");
    }
}