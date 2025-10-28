using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Infrastructure.Data;
using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Api;

public static class DbInitializer
{
    public static async Task InitializeAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        await db.Database.MigrateAsync();
        
        if (!await db.Vehicles.AnyAsync())
        {
            db.Vehicles.AddRange(
                new Vehicle { Make = "Toyota", Model = "Corolla", Year = 2019, Price = 11990 },
                new Vehicle { Make = "VW", Model = "Golf", Year = 2021, Price = 17990 }
            );
            await db.SaveChangesAsync();
        }
    }
}



