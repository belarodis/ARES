using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations;

public class ReservaLaboratorioRepository : IReservaLaboratorioRepository
{
    private readonly ARESDbContext _context;

    public ReservaLaboratorioRepository(ARESDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ReservaLaboratorio reservaLaboratorio)
    {
        await _context.ReservaLaboratorios.AddAsync(reservaLaboratorio);
        await _context.SaveChangesAsync();
    }

    public async Task<ReservaLaboratorio> GetByIdAsync(int id)
    {
        return await _context.ReservaLaboratorios.FindAsync(id);
    }

    public async Task<IEnumerable<ReservaLaboratorio>> GetAllAsync()
    {
        return await _context.ReservaLaboratorios
            .Include(r => r.Laboratorio)
            .Include(r => r.Funcionario)
            .ToListAsync();
    }

    // Implementação da verificação de disponibilidade do laboratório
    public async Task<bool> IsLaboratorioReservedOnDateAsync(int funcionarioId, DateOnly dataReserva)
    {
        return await _context.ReservaLaboratorios
            .AnyAsync(r => r.FkFuncionario == funcionarioId && r.DataReserva == dataReserva);
    }

    public async Task<bool> HasUserReservedOnDateAsync(int funcionarioId, DateOnly dataReserva)
    {
        return await _context.ReservaLaboratorios
            .AnyAsync(r => r.FkFuncionario == funcionarioId && r.DataReserva == dataReserva);
    }

    public async Task DeleteAsync(int id)
    {
        var reserva = await _context.ReservaLaboratorios.FindAsync(id);
        if (reserva != null)
        {
            _context.ReservaLaboratorios.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
}