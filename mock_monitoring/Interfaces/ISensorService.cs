namespace mock_monitoring.Interfaces;

using mock_monitoring.Models;

public interface ISensorService
{
    // Task RecordSensorDataAsync<T>(int sensorId, double value) where T : Sensor;
    Task<bool> IsSensorOutOfRangeAsync<T>(int sensorId, double value) where T : Sensor;
    
}
