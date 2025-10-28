namespace MiniVehicleAPI.Domain.Entities;

public class Owner
{
    public int Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; } // Telefonnummer ist optional

    // Ein Owner kann viele Fahrzeuge besitzen.
    // Wir initialisieren die Collection, um NullReferenceExceptions zu vermeiden.
    // Interface für die Collection verwenden, um Flexibilität bei der Implementierung zu gewährleisten.
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
