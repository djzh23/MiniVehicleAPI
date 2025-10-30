namespace MiniVehicleAPI.Application.Vehicles;

public record VehicleCreateDto (string Make, string Model, int Year, string? Vin, decimal Price);
public record VehicleUpdateDto (string? Make, string? Model, int? Year, string? Vin, decimal? Price);
public record VehicleReadDto(int Id, string Make, string Model, int Year, string? Vin, decimal Price, OwnerReadDto? Owner);

// Dto für Owner
public record OwnerReadDto(int Id, string Firstname, string  Lastname);
public record OwnerCreateDto(string Firstname, string Lastname, string Email, string? Phone);
public record OwnerUpdateDto(string? Firstname, string? Lastname, string? Email, string? Phone);
