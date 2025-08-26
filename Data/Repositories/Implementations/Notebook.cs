using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;

public class NotebookRepository : INotebookRepository
{
    private readonly ARESDbContext _context;

    public NotebookRepository(ARESDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Notebook notebook)
    {
        await _context.Notebooks.AddAsync(notebook);
        await _context.SaveChangesAsync();
    }

    public async Task<Notebook> GetByIdAsync(int id)
    {
        return await _context.Notebooks.FindAsync(id);
    }

    public async Task<IEnumerable<Notebook>> GetAllAsync()
    {
        return await _context.Notebooks.ToListAsync();
    }

    public async Task UpdateAsync(Notebook notebook)
    {
        _context.Notebooks.Update(notebook);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var notebook = await _context.Notebooks.FindAsync(id);
        if (notebook != null)
        {
            _context.Notebooks.Remove(notebook);
            await _context.SaveChangesAsync();
        }
    }
}