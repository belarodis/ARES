using Domain;

namespace Data.Repositories.Interfaces;

public interface ILaboratorioRepository
{
    Task<Laboratorio?> GetByIdAsync(int id);
    Task<IEnumerable<Laboratorio>> GetAllAsync();
    Task UpdateAsync(Laboratorio laboratorio);
}