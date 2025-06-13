using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mock_monitoring.Models;

namespace mock_monitoring.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MonitoringDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, MonitoringDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Sensors()
    {
        var sensors = _dbContext.Sensor.ToList();
        return View(sensors);
    }

    public IActionResult SensorLogs(int sensorId)
    {
        var logs = _dbContext.SensorLog.ToList();
        
        // if id given
        // var logs = _dbContext.SensorLog.ToList()
        //     .Where(log => log.SensorId == sensorId)
        //     .OrderByDescending(log => log.Timestamp)
        //     .ToList();
        return View(logs);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
