namespace mock_monitoring.Services;

using mock_monitoring.Models;
using mock_monitoring.Interfaces;
using mock_monitoring.Repository;
using System;

public class EventGeneratorService : BackgroundService
{

    private readonly IServiceProvider _serviceProvider;
    private  SensorRepository _sensorRepository;
    // private readonly ISensorService _sensorService;

    private readonly TimeSpan _interval = TimeSpan.FromSeconds(60);

    public EventGeneratorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await GenerateEventAsync<Sensor>(1, 25.0); 
            await Task.Delay(_interval, stoppingToken);
        }
    }



    public async Task<bool> GenerateEventAsync<T>(int sensorId, double value) where T : Sensor
    {
        using var scope = _serviceProvider.CreateScope();
        // var context = scope.ServiceProvider.GetRequiredService<MonitoringDbContext>();



        // var sensor = context.Sensor.Single(s => s.Id == sensorId);
        // if (sensor == null)
        // {
        //     throw new KeyNotFoundException($"Sensor with ID {sensorId} not found.");
        // }
        // _sensorRepository = new SensorRepository(context);

        _sensorRepository = scope.ServiceProvider.GetRequiredService<SensorRepository>();
        // Retrieve the sensor from the repository
        var sensor = await _sensorRepository.GetSensorAsync<T>(sensorId);
        if (sensor == null)
        {
            throw new KeyNotFoundException($"Sensor with ID {sensorId} not found.");
        }
        Console.WriteLine($"Sensor {sensor.Name} with ID {sensorId} has value {value}.");

        return false;


        // if (await _sensorService.IsSensorOutOfRangeAsync<T>(sensorId, value))
        // {
        //     //todo add evnt to evnt table 
        //     Console.WriteLine($"Event generated for sensor {sensorId} with value {value}.");

        // }
    }
}