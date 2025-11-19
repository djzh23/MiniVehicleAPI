using System.Linq.Expressions;

namespace MiniVehicleAPI.Domain.Abstractions;

public interface IRepository<T> where T : class
{
    // Fetch an entity by its ID
    Task<T?> GetByIdAsync(int id, CancellationToken ct = default);

    // Returns all entities as a list (read-only for performance)
    Task<IReadOnlyList<T>> ListAsync(CancellationToken ct = default);

    // Finds entities that match a predicate (condition)
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);

    // Adds a new entity
    Task AddAsync(T entity, CancellationToken ct = default);

    // Updates an existing entity
    Task UpdateAsync(T entity, CancellationToken ct = default);

    // Deletes an entity
    Task DeleteAsync(T entity, CancellationToken ct = default);

    // Checks if an entity with a specific ID exists in the database
    Task<bool> ExistAsync(int id, CancellationToken ct = default);

    // Saves the changes and returns the number of affected records
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}