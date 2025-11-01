using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Application.Owners;

public class OwnerService
{
    // repository injection
    private readonly IRepository<Owner> _repo;

    public OwnerService(IRepository<Owner> repository) => _repo = repository;

    // GetByIdAsync From IRepository interface ( _repo ) 
    // Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
    public async Task<OwnerReadDto?> GetAsync(int id, CancellationToken ct = default)
    {
        //OwnerReadDto owner = await _repo.GetByIdAsync(id, ct);
        // get owner from repository
        Owner? ownerEntity = await _repo.GetByIdAsync(id, ct);

        // check if the owner is null 
        // return null and logging ...
        if (ownerEntity == null)
        {
            // Optional: _logger.LogWarning("Owner with ID {Id} not found.", id);
            return null;
        }

        // map Owner to OwnerReadDto
        var ownerDto = new OwnerReadDto(
            Id: ownerEntity.Id,
            Firstname: ownerEntity.Firstname,
            Lastname: ownerEntity.Lastname
        );

        // return OwnerReadDto
        return ownerDto;
    }

    // Task AddAsync(T entity, CancellationToken ct = default);
    public async Task<int> CreateOwnerAsync(OwnerCreateDto owner, CancellationToken ct = default)
    {
        // add validation to the ownerCreateDto ( data validation )
        // map OwnerCreateDto to Owner entity
        var ownerEntity = new Owner
        {
            Firstname = owner.Firstname,
            Lastname = owner.Lastname,
            Email = owner.Email,
            Phone = owner.Phone
        };
        await _repo.AddAsync(ownerEntity, ct);
        await _repo.SaveChangesAsync(ct);
        return ownerEntity.Id;
    }
}
