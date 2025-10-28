namespace MiniVehicleAPI.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string? Vin { get; set; }
    public decimal Price { get; set; }
    public DateTime CreateAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateAtUtc { get; set; }
}