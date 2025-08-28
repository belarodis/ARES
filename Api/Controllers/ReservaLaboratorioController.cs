using Api.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/reserva-laboratorios")]
public class ReservaLaboratoriosController : ControllerBase
{
    private readonly IReservaLaboratorioService _reservaLaboratorioService;

    public ReservaLaboratoriosController(IReservaLaboratorioService reservaLaboratorioService)
    {
        _reservaLaboratorioService = reservaLaboratorioService;
    }

    // POST api/reservala-boratorios
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ReservaLaboratorio reservaLaboratorio)
    {
        bool success = await _reservaLaboratorioService.AddAsync(reservaLaboratorio);
        if (success)
        {
            return CreatedAtAction(nameof(GetById), new { id = reservaLaboratorio.Id }, reservaLaboratorio);
        }
        
        return BadRequest("Laboratório já reservado para a data ou o funcionário já tem uma reserva de notebook ou sala para o dia.");
    }
    
    // GET api/reserva-laboratorios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaLaboratorio>>> Get()
    {
        var reservas = await _reservaLaboratorioService.GetAllAsync();
        return Ok(reservas);
    }

    // GET api/reserva-laboratorios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ReservaLaboratorio>> GetById(int id)
    {
        var reserva = await _reservaLaboratorioService.GetByIdAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return Ok(reserva);
    }
    
    // DELETE api/reserva-laboratorios/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reservaLaboratorioService.DeleteAsync(id);
        return NoContent();
    }
}