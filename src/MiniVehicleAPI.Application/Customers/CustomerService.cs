using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Application.Customers;

public class CustomerService
{
    // repository injection
    private readonly IRepository<Customer> _repo;

    public CustomerService(IRepository<Customer> repository) => _repo = repository;

    // GetByIdAsync From IRepository interface ( _repo ) 
    // Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
    public async Task<CustomerReadDto?> GetAsync(int id, CancellationToken ct = default)
    {
        //OwnerReadDto owner = await _repo.GetByIdAsync(id, ct);
        // get owner from repository
        Customer? customerEntity = await _repo.GetByIdAsync(id, ct);

        // check if the owner is null 
        // return null and logging ...
        if (customerEntity == null)
        {
            // Optional: _logger.LogWarning("Owner with ID {Id} not found.", id);
            return null;
        }

        // map Owner to OwnerReadDto
        var ownerDto = new CustomerReadDto(
            Id: customerEntity.Id,
            Firstname: customerEntity.Firstname,
            Lastname: customerEntity.Lastname
        );

        // return OwnerReadDto
        return ownerDto;
    }

    // Task AddAsync(T entity, CancellationToken ct = default);
    public async Task<int> CreateCustomerAsync(CustomerCreateDto customer, CancellationToken ct = default)
    {
        // add validation to the ownerCreateDto ( data validation )
        // map OwnerCreateDto to Owner entity
        var customerEntity = new Customer
        {
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            Email = customer.Email,
            Phone = customer.Phone
        };
        await _repo.AddAsync(customerEntity, ct);
        await _repo.SaveChangesAsync(ct);
        return customerEntity.Id;
    }
}
