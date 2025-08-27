using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/reserva-notebooks")]
public class ReservaNotebooksController : ControllerBase
{
    private readonly IReservaNotebookService _reservaNotebookService;

    public ReservaNotebooksController(IReservaNotebookService reservaNotebookService)
    {
        _reservaNotebookService = reservaNotebookService;
    }

    // POST api/reserva-notebooks
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ReservaNotebook reservaNotebook)
    {
        bool success = await _reservaNotebookService.AddAsync(reservaNotebook);
        if (success)
        {
            return CreatedAtAction(nameof(GetById), new { id = reservaNotebook.Id }, reservaNotebook);
        }
        
        return BadRequest("Notebook já reservado para a data ou o funcionário já tem outra reserva para o dia.");
    }
    
    // GET api/reserva-notebooks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaNotebook>>> Get()
    {
        var reservas = await _reservaNotebookService.GetAllAsync();
        return Ok(reservas);
    }

    // GET api/reserva-notebooks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ReservaNotebook>> GetById(int id)
    {
        var reserva = await _reservaNotebookService.GetByIdAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return Ok(reserva);
    }
    
    // DELETE api/reserva-notebooks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reservaNotebookService.DeleteAsync(id);
        return NoContent();
    }
}