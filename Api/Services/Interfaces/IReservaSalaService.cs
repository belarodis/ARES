using Domain;
using Api.dtos;

namespace Api.Services.Interfaces;

public interface IReservaSalaService
{
    Task<bool> AddAsync(ReservaSala reservaSala);
    Task<ReservaSalaDto> GetByIdAsync(int id);
    Task<IEnumerable<ReservaSalaDto>> GetAllAsync();
    Task DeleteAsync(int id);
}