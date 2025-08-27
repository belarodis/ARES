using Domain;
using Microsoft.EntityFrameworkCore;
using Data.Repositories.Interfaces;
namespace Data.Repositories.Implementations;

public class LaboratorioRepository : ILaboratorioRepository
{
    private readonly ARESDbContext _context;

    public LaboratorioRepository(ARESDbContext context)
    {
        _context = context;
    }

    public async Task<Laboratorio?> GetByIdAsync(int id)
    {
        return await _context.Laboratorios.FindAsync(id);
    }

    public async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return await _context.Laboratorios.ToListAsync();
    }

    public async Task UpdateAsync(Laboratorio laboratorio)
    {
        _context.Laboratorios.Update(laboratorio);
        await _context.SaveChangesAsync();
    }
}