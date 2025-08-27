using Domain;

namespace Api.Services;

public interface IReservaSalaService
{
    Task<bool> AddAsync(ReservaSala reservaSala);
    Task<ReservaSala> GetByIdAsync(int id);
    Task<IEnumerable<ReservaSala>> GetAllAsync();
    Task DeleteAsync(int id);
}