using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Domain.Entities;
using MiniVehicleAPI.Infrastructure.Data;
using MiniVehicleAPI.Infrastructure.Repositories;

namespace MinivehicleAPI.Infrastructure.Repositories;

public class EfCustomerRepository : EfRepository<Customer>, ICustomerRepository
{
    private readonly AppDbContext _db;
    public EfCustomerRepository(AppDbContext db) : base(db) 
    {
        _db = db;
    }
    public async Task<bool> ExistByEmailAsync(string email, CancellationToken ct = default)
    {
        return await _db.Customers.AnyAsync(c => c.Email == email, ct);
    }
}
