namespace mock_monitoring.Repository;


using mock_monitoring.Models;
using mock_monitoring.Interfaces;
using Microsoft.EntityFrameworkCore;

public class SensorRepository
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

}