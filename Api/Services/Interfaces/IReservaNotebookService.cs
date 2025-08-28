using Domain;
using Api.dtos;

namespace Api.Services.Interfaces;

public interface IReservaNotebookService
{
    Task<bool> AddAsync(ReservaNotebook reservaNotebook);
    Task<ReservaNotebookDto> GetByIdAsync(int id);
    Task<IEnumerable<ReservaNotebookDto>> GetAllAsync();
    Task DeleteAsync(int id);
}