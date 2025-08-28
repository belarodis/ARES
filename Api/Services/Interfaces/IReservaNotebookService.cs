using Domain;

namespace Api.Services.Interfaces;

public interface IReservaNotebookService
{
    Task<bool> AddAsync(ReservaNotebook reservaNotebook);
    Task<ReservaNotebook> GetByIdAsync(int id);
    Task<IEnumerable<ReservaNotebook>> GetAllAsync();
    Task DeleteAsync(int id);
}