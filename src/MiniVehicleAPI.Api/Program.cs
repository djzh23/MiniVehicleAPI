using Microsoft.EntityFrameworkCore;
using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Infrastructure.Data;
using MiniVehicleAPI.Infrastructure.Repositories;
using MiniVehicleAPI.Domain.Entities;
using MiniVehicleAPI.Application.Customers;
using MiniVehicleAPI.Application.Vehicles;
using MinivehicleAPI.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// PostgreSQL-Datenbank
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IVehicleRepository,EfVehicleRepository>();
builder.Services.AddScoped<IRepository<Customer>, EfRepository<Customer>>();

builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<CustomerService>();

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

