using Api.Services.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/funcionarios")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    // GET api/funcionarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
    {
        var funcionarios = await _funcionarioService.GetAllAsync();
        return Ok(funcionarios);
    }

    // GET api/laboratorios/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Funcionario>> GetById(int id)
    {
        var funcionario = await _funcionarioService.GetByIdAsync(id);
        if (funcionario == null)
        {
            return NotFound();
        }
        return Ok(funcionario);
    }
}

