using Domain;

namespace Data.Repositories;

public interface IReservaSalaRepository
{
    Task AddAsync(ReservaSala reservaSala);

    Task<ReservaSala> GetByIdAsync(int id);
    Task<IEnumerable<ReservaSala>> GetAllAsync();
    
    Task<bool> IsSalaReservedOnDateAsync(int salaId, DateOnly dataReserva);

    Task DeleteAsync(int id);
}