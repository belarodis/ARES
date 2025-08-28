using Domain;

namespace Data.Repositories.Interfaces;

public interface ISalaRepository
{
    Task AddAsync(Sala sala);
    
    Task<Sala> GetByIdAsync(int id);
    Task<IEnumerable<Sala>> GetAllAsync();
    
    Task UpdateAsync(Sala sala);
    
    Task DeleteAsync(int id);
}