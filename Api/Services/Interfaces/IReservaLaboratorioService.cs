using Domain;
using Api.dtos;

namespace Api.Services.Interfaces;

public interface IReservaLaboratorioService
{
    Task<bool> AddAsync(ReservaLaboratorio reservaLaboratorio);
    Task<ReservaLaboratorioDto> GetByIdAsync(int id);
    Task<IEnumerable<ReservaLaboratorioDto>> GetAllAsync();
    Task DeleteAsync(int id);
}