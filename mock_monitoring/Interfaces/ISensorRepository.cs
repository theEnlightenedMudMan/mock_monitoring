namespace mock_monitoring.Interfaces;
using mock_monitoring.Models;

public interface ISensorRepository
    {
        Task<T> GetSensorAsync<T>(int sensorId) where T : Sensor;
        // Task UpdateSensorAsync<T>(T sensor) where T : Sensor;
    }
