using Data.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories.Implementations;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly ARESDbContext _context;

    public FuncionarioRepository(ARESDbContext context)
    {
        _context = context;
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        return await _context.Funcionarios.FindAsync(id);
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync()
    {
        return await _context.Funcionarios.ToListAsync();
    }
}