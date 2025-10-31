using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Domain.Entities;
using MiniVehicleAPI.Infrastructure.Data;
using MiniVehicleAPI.Infrastructure.Repositories;

namespace MinivehicleAPI.Infrastructure.Repositories;

public class EfVehicleRepository : EfRepository<Vehicle>, IVehicleRepository
{
    private readonly AppDbContext _db;
    public EfVehicleRepository(AppDbContext db) : base(db) {  
        _db = db;
    }
    public async Task<IReadOnlyList<Vehicle>> GetAllWithOnersAsync(CancellationToken ct = default)
    {
        return await _db.Vehicles
            .Include(v => v.Owner)
            .AsNoTracking()
            .ToListAsync(ct);
    }
}

