using Domain;

namespace Data.Repositories.Interfaces;

public interface INotebookRepository
{
    Task AddAsync(Notebook notebook);
    Task<Notebook> GetByIdAsync(int id);
    Task<IEnumerable<Notebook>> GetAllAsync();
    Task UpdateAsync(Notebook notebook);
    Task DeleteAsync(int id);
}