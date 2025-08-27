using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories;

public class ReservaNotebookRepository : IReservaNotebookRepository
{
    private readonly ARESDbContext _context;

    public ReservaNotebookRepository(ARESDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ReservaNotebook reservaNotebook)
    {
        await _context.ReservaNotebooks.AddAsync(reservaNotebook);
        await _context.SaveChangesAsync();
    }

    public async Task<ReservaNotebook> GetByIdAsync(int id)
    {
        return await _context.ReservaNotebooks.FindAsync(id);
    }

    public async Task<IEnumerable<ReservaNotebook>> GetAllAsync()
    {
        return await _context.ReservaNotebooks
            .Include(r => r.Notebook)
            .Include(r => r.Funcionario)
            .ToListAsync();
    }
    
    public async Task<bool> IsNotebookReservedOnDateAsync(int notebookId, DateOnly dataReserva)
    {
        return await _context.ReservaNotebooks
            .AnyAsync(r => r.FkNotebook == notebookId && r.DataReserva == dataReserva);
    }

    public async Task DeleteAsync(int id)
    {
        var reserva = await _context.ReservaNotebooks.FindAsync(id);
        if (reserva != null)
        {
            _context.ReservaNotebooks.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
}