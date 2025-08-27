using Data.Repositories;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services;

public class SalaService : ISalaService
{
    private readonly ISalaRepository _salaRepository;

    public SalaService(ISalaRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public async Task AddAsync(Sala sala)
    {
        await _salaRepository.AddAsync(sala);
    }

    public async Task<Sala> GetByIdAsync(int id)
    {
        return await _salaRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Sala>> GetAllAsync()
    {
        return await _salaRepository.GetAllAsync();
    }

    public async Task UpdateAsync(Sala sala)
    {
        await _salaRepository.UpdateAsync(sala);
    }

    public async Task DeleteAsync(int id)
    {
        await _salaRepository.DeleteAsync(id);
    }
}