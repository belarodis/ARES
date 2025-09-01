using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations;

public class SalaRepository : ISalaRepository
{
    private readonly ARESDbContext _context;

    public SalaRepository(ARESDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sala sala)
    {
        await _context.Salas.AddAsync(sala);
        await _context.SaveChangesAsync();
    }

    public async Task<Sala> GetByIdAsync(int id)
    {
        return await _context.Salas.FindAsync(id);
    }

    public async Task<IEnumerable<Sala>> GetAllAsync()
    {
        return await _context.Salas.ToListAsync();
    }

    public async Task UpdateAsync(Sala sala)
    {
        _context.Salas.Update(sala);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sala = await _context.Salas.FindAsync(id);
        if (sala != null)
        {
            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
        }
    }
}