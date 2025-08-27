using Domain;

namespace Api.Services.Interfaces;

public interface INotebookService
{
    Task AddAsync(Notebook notebook);
    Task<Notebook> GetByIdAsync(int id);
    Task<IEnumerable<Notebook>> GetAllAsync();
    Task UpdateAsync(Notebook notebook);
    Task DeleteAsync(int id);
}