using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Application.Vehicles;
using MiniVehicleAPI.Infrastructure.Data;
using FluentAssertions;
using MinivehicleAPI.Infrastructure.Repositories;

namespace MiniVehicleAPI.Tests;

public class VehicleServiceTests
{
    private static VehicleService CreateService()
    {
        var opts = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var db = new AppDbContext(opts);
        var repo = new EfVehicleRepository(db);
        return new VehicleService(repo);
    }
    
    [Fact]
    public async Task Create_And_Get()
    {
        var svc = CreateService();
        var id = await svc.CreateAsync(new("Toyota","Yaris",2020,null,9990));
        var got = await svc.GetAsync(id);
        got!.Model.Should().Be("Yaris");
    }
    
    [Fact]
    public async Task Create_With_Duplicate_VIN_Should_Throw()
    {
        var svc = CreateService();
        
        // Create first vehicle with VIN
        await svc.CreateAsync(new("Toyota", "Corolla", 2020, "VIN123", 15000));
        
        // Try to create second vehicle with same VIN - should throw
        var action = () => svc.CreateAsync(new("Honda", "Civic", 2021, "VIN123", 16000));
        await action.Should().ThrowAsync<ArgumentException>().WithMessage("VIN already exists");
    }
}
