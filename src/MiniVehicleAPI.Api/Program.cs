using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Application.Vehicles;
using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Infrastructure.Data;
using MiniVehicleAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL-Datenbank
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IRepository<MiniVehicleAPI.Domain.Entities.Vehicle>,
    EfRepository<MiniVehicleAPI.Domain.Entities.Vehicle>>();

builder.Services.AddScoped<VehicleService>();

// API + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

// Initialize database
await MiniVehicleAPI.Api.DbInitializer.InitializeAsync(app);

app.Run();

