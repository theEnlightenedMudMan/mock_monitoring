namespace mock_monitoring.Interfaces;
using mock_monitoring.Models;

public interface ISensorRepository
{
    //todo update sensorId to macAddress
    Task<T> GetSensorAsync<T>(int sensorId) where T : Sensor;
    Task AddReadingAsync<T>(int sensorId, float reading) where T : Sensor;
    
}
