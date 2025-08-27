using Domain;

namespace Data.Repositories.Interfaces;

public interface IFuncionarioRepository
{
    Task<Funcionario?> GetByIdAsync(int id);
    Task<IEnumerable<Funcionario>> GetAllAsync();
}