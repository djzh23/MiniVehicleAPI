namespace MiniVehicleAPI.Application.Vehicles;

public record VehicleCreateDto (string Make, string Model, int Year, string? Vin, decimal Price);
public record VehicleUpdateDto (string? Make, string? Model, int? Year, string? Vin, decimal? Price);
public record VehicleReadDto(int Id, string Make, string Model, int Year, string? Vin, decimal Price);
