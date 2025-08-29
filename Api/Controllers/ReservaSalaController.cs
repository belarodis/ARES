using Api.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/reserva-salas")]
public class ReservaSalasController : ControllerBase
{
    private readonly IReservaSalaService _reservaSalaService;

    public ReservaSalasController(IReservaSalaService reservaSalaService)
    {
        _reservaSalaService = reservaSalaService;
    }

    // POST api/reserva-salas
    // ...existing code...
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Api.dtos.ReservaSalaDto reservaSalaDto)
    {
        // Mapeamento manual do DTO para a entidade
        var reservaSala = new ReservaSala
        {
            FkFuncionario = reservaSalaDto.FkFuncionario,
            FkSala = reservaSalaDto.FkSala,
            DataReserva = reservaSalaDto.DataReserva
            // Adicione outros campos se necessário
        };

        bool success = await _reservaSalaService.AddAsync(reservaSala);
        if (success)
        {
            return CreatedAtAction(nameof(GetById), new { id = reservaSala.Id }, reservaSala);
        }

        return BadRequest("Sala já reservado para a data ou o funcionário já tem outra reserva para o dia.");
    }

    // GET api/reserva-salas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaSala>>> Get()
    {
        var reservas = await _reservaSalaService.GetAllAsync();
        return Ok(reservas);
    }

    // GET api/reserva-salas/5
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

    // DELETE api/reserva-salas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reservaSalaService.DeleteAsync(id);
        return NoContent();
    }
}