using Domain;

namespace Data.Repositories;

public interface IReservaNotebookRepository
{
    Task AddAsync(ReservaNotebook reservaNotebook);

    Task<ReservaNotebook> GetByIdAsync(int id);
    Task<IEnumerable<ReservaNotebook>> GetAllAsync();
    
    Task<bool> IsNotebookReservedOnDateAsync(int notebookId, DateOnly dataReserva);

    Task DeleteAsync(int id);
}