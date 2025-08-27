using Api.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotebooksController : ControllerBase
{
    private readonly INotebookService _notebookService;

    public NotebooksController(INotebookService notebookService)
    {
        _notebookService = notebookService;
    }

    // POST api/notebooks
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Notebook notebook)
    {
        await _notebookService.AddAsync(notebook);
        return CreatedAtAction(nameof(GetById), new { id = notebook.Id }, notebook);
    }

    // GET api/notebooks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Notebook>>> Get()
    {
        var notebooks = await _notebookService.GetAllAsync();
        return Ok(notebooks);
    }

    // GET api/notebooks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Notebook>> GetById(int id)
    {
        var notebook = await _notebookService.GetByIdAsync(id);
        if (notebook == null)
        {
            return NotFound();
        }
        return Ok(notebook);
    }
    
    // PUT api/notebooks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Notebook notebook)
    {
        if (id != notebook.Id)
        {
            return BadRequest();
        }
        await _notebookService.UpdateAsync(notebook);
        return NoContent();
    }

    // DELETE api/notebooks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _notebookService.DeleteAsync(id);
        return NoContent();
    }
}