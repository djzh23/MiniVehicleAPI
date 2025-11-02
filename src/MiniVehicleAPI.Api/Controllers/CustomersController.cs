using Microsoft.AspNetCore.Mvc;
using MiniVehicleAPI.Application.Customers;

namespace MiniVehicleAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    // service injection
    private readonly CustomerService _svc;
    public CustomersController(CustomerService svc) => _svc = svc;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerReadDto>> Get(int id)
    {
        var dto = await _svc.GetAsync(id);
        if (dto == null) return NotFound(); // 404
        return Ok(dto); // 200
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerReadDto>>> GetAll()
    {
        var dtos = await _svc.GetListAsync();
        if (dtos.Count == 0) return NoContent(); // 204
        return Ok(dtos); // 200
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CustomerCreateDto dto)
    {
        try
        {
            var newId = await _svc.CreateCustomerAsync(dto);
            return CreatedAtAction(nameof(Get), new { newId }, null); // 201
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message); // 409
        }     
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CustomerUpdateDto>> Update(int id, CustomerUpdateDto customerFromClient)
    {
        // 400 ( asp.net core does this automaticall, when Annotation validation fails) 
        bool wasUpdated = await _svc.UpdateCustomer(id, customerFromClient);
        if (!wasUpdated) return NotFound(); // 404
        return NoContent(); // 204 
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        bool wasDeleted = await _svc.DeleteCustomerAsync(id);
        if (!wasDeleted) return NotFound(); // 404
        return NoContent(); // 204
    }
}
