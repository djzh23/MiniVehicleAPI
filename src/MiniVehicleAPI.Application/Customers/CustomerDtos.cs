using System.ComponentModel.DataAnnotations;

namespace MiniVehicleAPI.Application.Customers;


public record CustomerReadDto(int Id, string Firstname, string Lastname);

// add data annotation for validation
public record CustomerCreateDto(
    [Required]
    string Firstname,
    [Required]
    string Lastname,
    [Required]
    [EmailAddress]
    string Email,
    [Phone]
    string? Phone);
public record CustomerUpdateDto(string? Firstname, string? Lastname, string? Email, string? Phone);

