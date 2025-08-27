using Domain;

namespace Api.Services.Interfaces;

public interface ILaboratorioService
{
    Task<Laboratorio?> GetByIdAsync(int id);
    Task<IEnumerable<Laboratorio>> GetAllAsync();
    Task UpdateAsync(Laboratorio laboratorio);
}