using Data.Repositories;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class ReservaNotebookService : IReservaNotebookService
{
    private readonly IReservaNotebookRepository _reservaNotebookRepository;
    private readonly IReservaSalaRepository _reservaSalaRepository; 
    private readonly INotebookRepository _notebookRepository;

    public ReservaNotebookService(IReservaNotebookRepository reservaNotebookRepository, IReservaSalaRepository reservaSalaRepository, INotebookRepository notebookRepository)
    {
        _reservaNotebookRepository = reservaNotebookRepository;
        _reservaSalaRepository = reservaSalaRepository;
        _notebookRepository = notebookRepository;
    }

    public async Task<bool> AddAsync(ReservaNotebook reservaNotebook)
    {
        bool isReserved = await _reservaNotebookRepository.IsNotebookReservedOnDateAsync(reservaNotebook.FkNotebook, reservaNotebook.DataReserva);
        if (isReserved)
        {
            return false;
        }

        await _reservaNotebookRepository.AddAsync(reservaNotebook);
        return true;
    }

    public async Task<ReservaNotebook> GetByIdAsync(int id)
    {
        return await _reservaNotebookRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ReservaNotebook>> GetAllAsync()
    {
        return await _reservaNotebookRepository.GetAllAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _reservaNotebookRepository.DeleteAsync(id);
    }
}