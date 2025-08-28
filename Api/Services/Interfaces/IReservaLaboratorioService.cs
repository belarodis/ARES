using Domain;

namespace Api.Services.Interfaces;

public interface IReservaLaboratorioService
{
    Task<bool> AddAsync(ReservaLaboratorio reservaLaboratorio);
    Task<ReservaLaboratorio> GetByIdAsync(int id);
    Task<IEnumerable<ReservaLaboratorio>> GetAllAsync();
    Task DeleteAsync(int id);
}