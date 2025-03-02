using System.Text.Json;

public sealed class CheckEnvironment : IHostedService
{
    private readonly IHostEnvironment _environment;
    private readonly ILogger _logger;
    public CheckEnvironment(IHostEnvironment environment, ILogger<CheckEnvironment> logger)
    {
        _environment = environment;
        _logger = logger;
        // We can also change environment
        // _environment.EnvironmentName = "Development";
        // throw new Exception("Hi");
        PrintEnvironment();

    }

    private void PrintEnvironment()
    {
        _logger.LogInformation("is development: {}", _environment.IsDevelopment());
        _logger.LogInformation(JsonSerializer.Serialize(_environment));
        _logger.LogInformation(_environment.ApplicationName);
        _logger.LogInformation(_environment.EnvironmentName);
    }

    Task IHostedService.StartAsync(System.Threading.CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    Task IHostedService.StopAsync(System.Threading.CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }


}