using System.ComponentModel.DataAnnotations;

namespace MiniVehicleAPI.Application.Customers;


public record CustomerReadDto(int Id, string Firstname, string Lastname);

// add data annotation for validation
public record CustomerCreateDto(
    [Required(ErrorMessage = "Firstname is required")]
    [StringLength(100, ErrorMessage = "Firstname cannot be longer than 100 characters")]
    string Firstname,
    [Required(ErrorMessage = "Lastname is required")]
    [StringLength(100, ErrorMessage = "Lasttname cannot be longer than 100 characters")]
    string Lastname,
    [Required]
    [EmailAddress]
    string Email,
    [Phone]
    string? Phone);
public record CustomerUpdateDto(
    [Required]
    [StringLength(100)]
    string Firstname,
    [Required]
    [StringLength(100)]
    string Lastname,
    [Required]
    [EmailAddress]
    string Email,
    string? Phone
    );

