using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mock_monitoring.Models;

public class SensorLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int SensorId { get; set; }

    [Required]
    public int Timestamp { get; set; }

    [Required]
    public float Temp { get; set; }

    [Required]
    public bool Enable { get; set; }

    [Required]
    [Column(TypeName = "tinyint(4)")]
    public int Status { get; set; } = 0; // 0 = Normal, 1 = Low, 2 = High

    [Required]
    [Column(TypeName = "tinyint(4)")]
    public int Quality { get; set; } = 0; // 0 = Good, 1 = Link

    [Required]
    public float High { get; set; }


    [Required]
    public float Low { get; set; }
}