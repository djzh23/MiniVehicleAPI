using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Infrastructure.Data;
using System.Linq.Expressions;

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

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => await _set.AsNoTracking().Where(predicate).ToListAsync(ct);

    public Task AddAsync(T entity, CancellationToken ct = default)
    {
        return _set.AddAsync(entity, ct).AsTask();
    }

    public Task UpdateAsync(T entity, CancellationToken ct = default)
    {
        _set.Update(entity);
        return Task.CompletedTask; // Operation is synchronous, but returns a task
    }

    public Task DeleteAsync(T entity, CancellationToken ct = default)
    {
        _db.Entry(entity).State = EntityState.Deleted;
        _set.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<bool> ExistAsync(int id, CancellationToken ct = default)
    {
        return await _set.FindAsync(new object?[] { id }, ct) != null;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _db.SaveChangesAsync(ct);
    }
}