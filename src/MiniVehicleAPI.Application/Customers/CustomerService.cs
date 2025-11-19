using MiniVehicleAPI.Domain.Abstractions;
using MiniVehicleAPI.Domain.Entities;

namespace MiniVehicleAPI.Application.Customers;

public class CustomerService
{
    // repository injection
    private readonly ICustomerRepository _repo;

    public CustomerService(ICustomerRepository repository) => _repo = repository;

    public async Task<bool> UpdateCustomer(int id, CustomerUpdateDto updateDto, CancellationToken ct = default)
    {
        var customerToUpdate = await _repo.GetByIdAsync(id, ct);
        if (customerToUpdate == null) return false;

        customerToUpdate.Firstname = updateDto.Firstname;
        customerToUpdate.Lastname = updateDto.Lastname;
        customerToUpdate.Phone = updateDto.Phone;
        customerToUpdate.Email = updateDto.Email;

        await _repo.SaveChangesAsync(ct);

        return true;
    }

    public async Task<CustomerReadDto?> GetAsync(int id, CancellationToken ct = default)
    {
        // get owner from repository
        Customer? customerEntity = await _repo.GetByIdAsync(id, ct);

        // check if the owner is null 
        if (customerEntity == null)
        {
            return null;
        }

        // map Owner to OwnerReadDto
        var ownerDto = new CustomerReadDto(
            Id: customerEntity.Id,
            Firstname: customerEntity.Firstname,
            Lastname: customerEntity.Lastname
        );

        return ownerDto;
    }

    public async Task<IReadOnlyList<CustomerReadDto>> GetListAsync(CancellationToken ct = default)
    {
        var customerEntities = await _repo.ListAsync(ct);

        if(customerEntities == null || !customerEntities.Any())
        {
            return Array.Empty<CustomerReadDto>();
        }

        var customerDtos = customerEntities.Select(customer => new CustomerReadDto(
            Id: customer.Id,
            Firstname: customer.Firstname,
            Lastname: customer.Lastname
        )).ToList();

        return customerDtos;
    }

    public async Task<int> CreateCustomerAsync(CustomerCreateDto customer, CancellationToken ct = default)
    {
        // check if email already exists
        if(_repo.ExistByEmailAsync(customer.Email, ct).Result)
        {
            throw new InvalidOperationException("A customer with this email address already exists.");
        }

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

    public async Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default)
    {

        var customerToDelete = await _repo.GetByIdAsync(id, ct);
        if (customerToDelete == null) return false;

        await _repo.DeleteAsync(customerToDelete, ct);
        await _repo.SaveChangesAsync(ct);
        return true;

    }

}
