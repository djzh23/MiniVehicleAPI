namespace MiniVehicleAPI.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string? Vin { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }

    // Ein Fahrzeug gehört zu genau einem Owner. Die Id kann null sein (wenn das Fahrzeug noch keinen Besitzer hat).
    public int? CustomerId { get; set; } // Foreign Key zur Owner-Entität

    // Die Navigation Property zum Owner-Objekt. Auch diese ist nullable.
    public Customer? Customer { get; set; }
}