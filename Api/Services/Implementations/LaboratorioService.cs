using Api.Services.Interfaces;
using Data.Repositories.Interfaces;
using Data.Repositories;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Implementations;

public class LaboratorioService : ILaboratorioService
{
    private readonly ILaboratorioRepository _laboratorioRepository;

    public LaboratorioService(ILaboratorioRepository laboratorioRepository)
    {
        _laboratorioRepository = laboratorioRepository;
    }

    public async Task<Laboratorio?> GetByIdAsync(int id)
    {
        return await _laboratorioRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return await _laboratorioRepository.GetAllAsync();
    }

    public async Task UpdateAsync(Laboratorio laboratorio)
    {
        await _laboratorioRepository.UpdateAsync(laboratorio);
    }
}