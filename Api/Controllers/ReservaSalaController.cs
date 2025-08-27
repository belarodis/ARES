using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservaSalasController : ControllerBase
{
    private readonly IReservaSalaService _reservaSalaService;

    public ReservaSalasController(IReservaSalaService reservaSalaService)
    {
        _reservaSalaService = reservaSalaService;
    }

    // POST api/reservasalas
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ReservaSala reservaSala)
    {
        bool success = await _reservaSalaService.AddAsync(reservaSala);
        if (success)
        {
            return CreatedAtAction(nameof(GetById), new { id = reservaSala.Id }, reservaSala);
        }
        
        return BadRequest("Sala já reservada para a data ou o funcionário já tem outra reserva não permitida para o dia.");
    }
    
    // GET api/reservasalas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaSala>>> Get()
    {
        var reservas = await _reservaSalaService.GetAllAsync();
        return Ok(reservas);
    }

    // GET api/reservasalas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ReservaSala>> GetById(int id)
    {
        var reserva = await _reservaSalaService.GetByIdAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return Ok(reserva);
    }
    
    // DELETE api/reservasalas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reservaSalaService.DeleteAsync(id);
        return NoContent();
    }
}