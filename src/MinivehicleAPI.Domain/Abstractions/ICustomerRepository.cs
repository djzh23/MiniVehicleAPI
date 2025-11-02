using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Domain.Abstractions;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<bool> ExistByEmailAsync(string email, CancellationToken ct = default); 
}
