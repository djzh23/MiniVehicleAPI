namespace MiniVehicleAPI.Application.Owners;


public record OwnerReadDto(int Id, string Firstname, string Lastname);
public record OwnerCreateDto(string Firstname, string Lastname, string Email, string? Phone);
public record OwnerUpdateDto(string? Firstname, string? Lastname, string? Email, string? Phone);

