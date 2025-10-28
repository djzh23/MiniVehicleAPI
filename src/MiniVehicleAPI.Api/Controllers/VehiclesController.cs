using Microsoft.AspNetCore.Mvc;
using MiniVehicleAPI.Application.Vehicles;

namespace MiniVehicleAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly VehicleService _svc;

    public VehiclesController(VehicleService svc) => _svc = svc;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<VehicleReadDto>>> List()
        => Ok(await _svc.ListAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VehicleReadDto>> Get(int id)
        => (await _svc.GetAsync(id)) is { } dto? Ok(dto) : NotFound();

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] VehicleCreateDto dto)
    {
        var id = await _svc.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] VehicleUpdateDto dto)
        => await _svc.UpdateAsync(id, dto) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
        => await _svc.DeleteAsync(id) ? NoContent() : NotFound();

}