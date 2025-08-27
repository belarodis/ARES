using Domain;

namespace Api.Services.Interfaces;

public interface IFuncionarioService
{
    Task<Funcionario?> GetByIdAsync(int id);
    Task<IEnumerable<Funcionario>> GetAllAsync();
}