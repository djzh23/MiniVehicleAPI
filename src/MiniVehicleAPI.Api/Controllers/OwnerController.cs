using Microsoft.AspNetCore.Mvc;
using MiniVehicleAPI.Application.Owners;

namespace MiniVehicleAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    // service injection
    private readonly OwnerService _svc;
    public OwnerController(OwnerService svc) => _svc = svc;

    //[HttpGet("{id:int}")]
    //public async Task<ActionResult <OwnerReadDto>> Get(int id)
    //    => (await _svc.GetAsync(id)) is { } dto ? Ok(dto) : NotFound();

    // Im Controller: Korrekt!
    [HttpGet("{id:int}")]
    public async Task<ActionResult<OwnerReadDto>> Get(int id)
    {
        var dto = await _svc.GetAsync(id);
        if (dto == null) return NotFound(); // Controller übersetzt zu HTTP 404
        return Ok(dto); // Controller übersetzt zu HTTP 200 mit JSON-Body
    }



}
