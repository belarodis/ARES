using Api.Services.Interfaces;
using Data.Repositories.Interfaces;
using Domain;

namespace Api.Services.Implementations;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        return await _funcionarioRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync()
    {
        return await _funcionarioRepository.GetAllAsync();
    }
}