namespace mock_monitoring.Repository;


using mock_monitoring.Models;
using mock_monitoring.Interfaces;
using Microsoft.EntityFrameworkCore;

public class SensorRepository : ISensorRepository
{
    private readonly MonitoringDbContext _dbContext;
    public SensorRepository(MonitoringDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetSensorAsync<T>(int sensorId) where T : Sensor
        // public async Task<T> GetSensorAsync(int sensorId) where T : Sensor
    {
        var sensor = await _dbContext.Set<T>().FirstOrDefaultAsync(s => s.Id == sensorId);

        if (sensor == null)
        {
            throw new KeyNotFoundException($"Sensor with ID {sensorId} not found.");
        }
        return sensor;
    }
    
    public async Task AddReadingAsync<T>(int sensorId, float reading) where T : Sensor
    {
        var sensor = await GetSensorAsync<T>(sensorId);
        var log = sensor.addReading(reading);

        _dbContext.SensorLog.Add(log);
        await _dbContext.SaveChangesAsync();
    }

}