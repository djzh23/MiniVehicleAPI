using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Domain.Abstractions;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<IReadOnlyList<Vehicle>> GetAllWithOnersAsync(CancellationToken ct = default);
}
