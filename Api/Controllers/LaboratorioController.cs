using Api.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/laboratorios")]
public class LaboratorioController : ControllerBase
{
    private readonly ILaboratorioService _laboratorioService;

    public LaboratorioController(ILaboratorioService laboratorioService)
    {
        _laboratorioService = laboratorioService;
    }

    // GET api/laboratorios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Laboratorio>>> Get()
    {
        var laboratorios = await _laboratorioService.GetAllAsync();
        return Ok(laboratorios);
    }

    // GET api/laboratorios/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Laboratorio>> GetById(int id)
    {
        var laboratorio = await _laboratorioService.GetByIdAsync(id);
        if (laboratorio == null)
        {
            return NotFound();
        }
        return Ok(laboratorio);
    }
    
    // PUT api/laboratorios/id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Laboratorio laboratorio)
    {
        if (id != laboratorio.Id)
        {
            return BadRequest();
        }
        await _laboratorioService.UpdateAsync(laboratorio);
        return NoContent();
    }
}