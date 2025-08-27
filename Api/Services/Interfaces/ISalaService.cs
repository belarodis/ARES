using Domain;

namespace Api.Services;

public interface ISalaService
{
    Task AddAsync(Sala sala);
    Task<Sala> GetByIdAsync(int id);
    Task<IEnumerable<Sala>> GetAllAsync();
    Task UpdateAsync(Sala sala);
    Task DeleteAsync(int id);
}