using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

using mock_monitoring.Models;
namespace mock_monitoring.Mock_Sensor;

public class SensorDataGeneratorService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(120);
    private readonly Random _random = new Random();

    public SensorDataGeneratorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await GenerateMockSensorData(stoppingToken);
            await Task.Delay(_interval, stoppingToken);
        }
    }

    private async Task GenerateMockSensorData(CancellationToken stoppingToken)
    {
        // Create a new scope to resolve DbContext
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MonitoringDbContext>();

        var mockReading = new SensorLog
        {
            SensorId = 1,
            Timestamp = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Temp = (float)(_random.NextDouble() * 35 + 15), // Random temperature between 15 and 50
            Enable = true,
            High = 30, //todo get from profile
            Low = 45 // todo get from profile

        };


        context.SensorLog.Add(mockReading);
        
        await context.SaveChangesAsync(stoppingToken);


        Console.WriteLine($"Added mock sensor: {mockReading.Id} at {DateTime.UtcNow}");
    }
}