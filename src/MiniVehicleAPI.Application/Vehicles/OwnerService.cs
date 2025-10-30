using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Application.Vehicles;

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
        //return owner;
        return null;
    }

    // Task AddAsync(T entity, CancellationToken ct = default);
    public async Task<int> CreateOwnerAsync(Owner owner, CancellationToken ct = default)
    {
        await _repo.AddAsync(owner, ct);
        await _repo.SaveChangesAsync(ct);
        return owner.Id;
    }
}
