using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Infrastructure.Data;

namespace MiniVehicleAPI.Infrastructure.Repositories;

public class EfRepository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private readonly DbSet<T> _set;

    public EfRepository(AppDbContext db)
    {
        _db = db;
        _set = _db.Set<T>();
    }

    public Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        => _set.FindAsync(new object?[] { id }, ct).AsTask();

    public async Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default)
        => await _set.AsNoTracking().ToListAsync(ct);

    //public async Task<IReadOnlyList<T>> GetAllWithOwnersAsync(CancellationToken ct = default)
    //{
    //    return await _db.Vehicles
    //        .Include( v => v.Owner)
    //        .AsNoTracking()
    //        .ToListAsync(ct) as List<T>;
    //}
    public async Task AddAsync(T entity, CancellationToken ct = default)
    {
        await _set.AddAsync(entity, ct);
        // Don't save automatically - let the service layer handle transactions
    }

    public async Task UpdateAsync(T entity, CancellationToken ct = default)
    {
        _set.Update(entity);
        // Don't save automatically - let the service layer handle transactions
    }

    public async Task DeleteAsync(T entity, CancellationToken ct = default)
    {
        _set.Remove(entity);
        // Don't save automatically - let the service layer handle transactions
    }

    public async Task<bool> ExistAsync(T obj, CancellationToken ct = default)
    {
        return await _set.ContainsAsync(obj, ct);
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _db.SaveChangesAsync(ct);
    }
}