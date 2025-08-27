using Api.Services.Interfaces;
using Data.Repositories.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Implementations;

public class NotebookService : INotebookService
{
    private readonly INotebookRepository _notebookRepository;

    public NotebookService(INotebookRepository notebookRepository)
    {
        _notebookRepository = notebookRepository;
    }

    public async Task AddAsync(Notebook notebook)
    {
        await _notebookRepository.AddAsync(notebook);
    }

    public async Task<Notebook?> GetByIdAsync(int id)
    {
        return await _notebookRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Notebook>> GetAllAsync()
    {
        return await _notebookRepository.GetAllAsync();
    }

    public async Task UpdateAsync(Notebook notebook)
    {
        await _notebookRepository.UpdateAsync(notebook);
    }

    public async Task DeleteAsync(int id)
    {
        await _notebookRepository.DeleteAsync(id);
    }
}