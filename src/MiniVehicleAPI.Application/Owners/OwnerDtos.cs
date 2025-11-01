using System.ComponentModel.DataAnnotations;

namespace MiniVehicleAPI.Application.Owners;


public record OwnerReadDto(int Id, string Firstname, string Lastname);

// add data annotation for validation
public record OwnerCreateDto(
    [Required]
    string Firstname,
    [Required]
    string Lastname,
    [Required]
    [EmailAddress]
    string Email,
    [Phone]
    string? Phone);
public record OwnerUpdateDto(string? Firstname, string? Lastname, string? Email, string? Phone);

