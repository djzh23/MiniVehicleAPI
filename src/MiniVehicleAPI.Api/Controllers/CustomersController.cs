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

    //[HttpGet("{id:int}")]
    //public async Task<ActionResult <OwnerReadDto>> Get(int id)
    //    => (await _svc.GetAsync(id)) is { } dto ? Ok(dto) : NotFound();

    // Im Controller: Korrekt!
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerReadDto>> Get(int id)
    {
        var dto = await _svc.GetAsync(id);
        if (dto == null) return NotFound(); // Controller übersetzt zu HTTP 404
        return Ok(dto); // Controller übersetzt zu HTTP 200 mit JSON-Body
    }


    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CustomerCreateDto dto)
    {
        var id = await _svc.CreateCustomerAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }


}
