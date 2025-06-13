using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace mock_monitoring.Models;

public abstract class Sensor
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? MacAddress { get; set; }

    [Required]
    public int ProfileId { get; set; }

    [Required]
    public int Sample_Period { get; set; }

    [Required]
    public int Type { get; set; } = 0; // 104 = Temperature, 113 = Temp/Humidity,

    [Required]
    public bool Enable { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "tinyint(4)")]
    public int Alarmen { get; set; } = 0;

    abstract public bool IsOutOfRange(float reading);


}