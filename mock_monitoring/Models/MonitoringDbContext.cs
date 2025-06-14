using Microsoft.EntityFrameworkCore;

namespace mock_monitoring.Models;

public class MonitoringDbContext : DbContext
{

    public DbSet<Sensor> Sensor { get; set; } = null!;
    public DbSet<SensorLog> SensorLog { get; set; } = null!;

    public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // TPH Sensor inheritance mapping
        modelBuilder.Entity<Sensor>()
                .ToTable("Sensor")
                .HasDiscriminator<int>("Type")
                .HasValue<TemperatureSensor>(104);
                // .HasValue<TempHumiditySensor>(113);

        base.OnModelCreating(modelBuilder);
        //seed mock temperature sensor
        modelBuilder.Entity<TemperatureSensor>().HasData(
            new TemperatureSensor()
            {
                Id = 1,
                Name = "Mock Sensor 1",
                MacAddress = "00:11:22:33:44:55",
                ProfileId = 1,
                Sample_Period = 900,
                Enable = true,
                Type = 104, 
                CreatedAt = DateTime.UtcNow,
                Alarmen = 0
            }
        );
    }
}