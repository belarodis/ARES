using Domain;

namespace Data.Repositories;

public interface IReservaLaboratorioRepository
{
    Task AddAsync(ReservaLaboratorio reservaLaboratorio);

    Task<ReservaLaboratorio> GetByIdAsync(int id);
    Task<IEnumerable<ReservaLaboratorio>> GetAllAsync();
    
    Task<bool> IsLaboratorioReservedOnDateAsync(int laboratorioId, DateOnly dataReserva);
    
    Task<bool> HasUserReservedOnDateAsync(int funcionarioId, DateOnly dataReserva);

    Task DeleteAsync(int id);
}