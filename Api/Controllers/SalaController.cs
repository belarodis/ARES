using Api.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/salas")]
public class SalasController : ControllerBase
{
    private readonly ISalaService _salaService;

    public SalasController(ISalaService salaService)
    {
        _salaService = salaService;
    }

    // POST api/salas
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Sala sala)
    {
        await _salaService.AddAsync(sala);
        return CreatedAtAction(nameof(GetById), new { id = sala.Id }, sala);
    }

    // GET api/salas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sala>>> Get()
    {
        var salas = await _salaService.GetAllAsync();
        return Ok(salas);
    }

    // GET api/salas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Sala>> GetById(int id)
    {
        var sala = await _salaService.GetByIdAsync(id);
        if (sala == null)
        {
            return NotFound();
        }
        return Ok(sala);
    }
    
    // PUT api/salas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Sala sala)
    {
        if (id != sala.Id)
        {
            return BadRequest();
        }
        await _salaService.UpdateAsync(sala);
        return NoContent();
    }

    // DELETE api/salas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _salaService.DeleteAsync(id);
        return NoContent();
    }
}