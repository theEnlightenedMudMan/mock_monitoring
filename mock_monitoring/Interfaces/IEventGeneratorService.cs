namespace mock_monitoring.Interfaces;

using mock_monitoring.Models;

public interface IEventGeneratorService
{
    Task<bool> GenerateEventAsync<T>(int sensorId, double value) where T : Sensor;
    
}
