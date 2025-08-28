using Api.Services;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.dtos;

namespace Api.Services.Implementations;

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

    public async Task<ReservaNotebookDto> GetByIdAsync(int id)
    {
        var reserva = await _reservaNotebookRepository.GetByIdAsync(id);
        if (reserva == null) return null;

        return new ReservaNotebookDto
        {
            Id = reserva.Id,
            FkFuncionario = reserva.FkFuncionario,
            FkNotebook = reserva.FkNotebook,
            DataReserva = reserva.DataReserva,
            NomeFuncionario = reserva.Funcionario?.Nome,
            NomeNotebook = reserva.Notebook?.NPatrimonio
        };
    }

    public async Task<IEnumerable<ReservaNotebookDto>> GetAllAsync()
    {
        var reservas = await _reservaNotebookRepository.GetAllAsync();
        return reservas.Select(reserva => new ReservaNotebookDto
        {
            Id = reserva.Id,
            FkFuncionario = reserva.FkFuncionario,
            FkNotebook = reserva.FkNotebook,
            DataReserva = reserva.DataReserva,
            NomeFuncionario = reserva.Funcionario?.Nome,
            NomeNotebook = reserva.Notebook?.NPatrimonio
        });
    }

    public async Task DeleteAsync(int id)
    {
        await _reservaNotebookRepository.DeleteAsync(id);
    }
}