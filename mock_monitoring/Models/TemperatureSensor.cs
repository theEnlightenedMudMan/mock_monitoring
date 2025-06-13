
using System.Runtime;

namespace mock_monitoring.Models;
public class TemperatureSensor : Sensor
{
    private const int minTemp = 30;
    private const int maxTemp = 45;
    // todo private Profile temperatureProfile;

    public override bool IsOutOfRange(float reading)
    {
        return reading < minTemp || reading > maxTemp;
    }
}