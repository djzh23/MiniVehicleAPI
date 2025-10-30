using MiniVehicleAPI.Application.Owners;
using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Application.Vehicles;

public class VehicleService
{
    private readonly IRepository<Vehicle> _repo;

    public VehicleService(IRepository<Vehicle> repo) => _repo = repo;

    public async Task<VehicleReadDto?> GetAsync(int id, CancellationToken ct = default)
    {
        var v = await _repo.GetByIdAsync(id, ct);
        return v is null ? null : Map(v);
    }
    

    public async Task<IReadOnlyList<VehicleReadDto>> ListAsync(CancellationToken ct = default)
    {
        var list = await _repo.ListAsync(ct);
        return list.Select(Map).ToList();
    }

    public async Task<List<VehicleReadDto>> GetlAllVehiclesWithOwnersAsync(CancellationToken ct = default)
    {
        var vehiclesFromDb = await _repo.GetAllWithOwnersAsync(ct);

        // public record VehicleReadDto(int Id, string Make, string Model, int Year, string? Vin, decimal Price, OwnerReadDto? Owner);

        var vehicleDtos = vehiclesFromDb.Select(v => new VehicleReadDto(
            v.Id,
            v.Make,
            v.Model,
            v.Year,
            v.Vin,
            v.Price,
            // Der ternäre Operator, um Null-Reference Exceptions zu vermeiden
            v.Owner == null ? null : new OwnerReadDto(v.Owner.Id, v.Owner.Firstname, v.Owner.Lastname)
        )).ToList();


        return vehicleDtos;
    }

    public async Task<int> CreateAsync(VehicleCreateDto dto, CancellationToken ct = default)
    {
        Validate(dto);
        
        // Check if VIN already exists (if VIN is provided) - BEFORE creating the vehicle
        if (!string.IsNullOrWhiteSpace(dto.Vin))
        {
            var existingVehicles = await _repo.ListAsync(ct);
            if (existingVehicles.Any(v => v.Vin == dto.Vin.Trim()))
                throw new ArgumentException("VIN already exists");
        }
        
        var vehicle = new Vehicle
        {
            Make = dto.Make.Trim(),
            Model = dto.Model.Trim(),
            Year = dto.Year,
            Vin = string.IsNullOrWhiteSpace(dto.Vin) ? null : dto.Vin.Trim(),
            Price = dto.Price,
        };
        
        await _repo.AddAsync(vehicle, ct);
        await _repo.SaveChangesAsync(ct);
        return vehicle.Id;
    }

    public async Task<bool> UpdateAsync(int id, VehicleUpdateDto dto, CancellationToken ct = default)
    {
        var v = await _repo.GetByIdAsync(id, ct);
        if(v is null) return false;

        if(!string.IsNullOrWhiteSpace(dto.Make)) v.Make = dto.Make.Trim();
        if(!string.IsNullOrWhiteSpace(dto.Model)) v.Model = dto.Model.Trim();
        if(dto.Year.HasValue) v.Year = dto.Year.Value;
        if(dto.Vin is not null) v.Vin = string.IsNullOrWhiteSpace(dto.Vin) ? null : dto.Vin.Trim();
        if(dto.Price.HasValue) v.Price = dto.Price.Value;
        v.UpdatedAtUtc = DateTime.UtcNow;

        await _repo.UpdateAsync(v, ct);
        await _repo.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var v = await _repo.GetByIdAsync(id, ct);
        if(v is null) return false;

        await _repo.DeleteAsync(v, ct);
        await _repo.SaveChangesAsync(ct);
        return true;
    }

    private static VehicleReadDto Map(Vehicle v)
        => new VehicleReadDto(
            v.Id,
            v.Make,
            v.Model,
            v.Year,
            v.Vin,
            v.Price,
            v.Owner is null ? null : new OwnerReadDto(v.Owner.Id, v.Owner.Firstname, v.Owner.Lastname)
        );

    private static void Validate(VehicleCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Make) || dto.Make.Length < 2)
            throw new ArgumentException("Make too short");
        if (string.IsNullOrWhiteSpace(dto.Model))
            throw new ArgumentException("Model required");
        if (dto.Year < 1950 || dto.Year > DateTime.UtcNow.Year + 1)
            throw new ArgumentException("Year out of range");
        if (dto.Price < 0)
            throw new ArgumentException("Price must be >= 0");
    }

}