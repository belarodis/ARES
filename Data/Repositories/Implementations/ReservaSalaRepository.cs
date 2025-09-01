using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations;

public class ReservaSalaRepository : IReservaSalaRepository
{
    private readonly ARESDbContext _context;

    public ReservaSalaRepository(ARESDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ReservaSala reservaSala)
    {
        await _context.ReservaSalas.AddAsync(reservaSala);
        await _context.SaveChangesAsync();
    }

    public async Task<ReservaSala> GetByIdAsync(int id)
    {
        return await _context.ReservaSalas.FindAsync(id);
    }

    public async Task<IEnumerable<ReservaSala>> GetAllAsync()
    {
        return await _context.ReservaSalas
            .Include(r => r.Sala)
            .Include(r => r.Funcionario)
            .ToListAsync();
    }

    public async Task<bool> IsSalaReservedOnDateAsync(int funcionarioId, DateOnly dataReserva)
    {
        return await _context.ReservaSalas
            .AnyAsync(r => r.FkFuncionario == funcionarioId && r.DataReserva == dataReserva);
    }

    public async Task DeleteAsync(int id)
    {
        var reserva = await _context.ReservaSalas.FindAsync(id);
        if (reserva != null)
        {
            _context.ReservaSalas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
}