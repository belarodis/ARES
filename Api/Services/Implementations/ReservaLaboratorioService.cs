using Data.Repositories.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.dtos;
using System.Linq;

namespace Api.Services.Implementations;

public class ReservaLaboratorioService : IReservaLaboratorioService
{
    private readonly IReservaLaboratorioRepository _reservaLaboratorioRepository;
    private readonly IReservaNotebookRepository _reservaNotebookRepository;
    private readonly IReservaSalaRepository _reservaSalaRepository;

    public ReservaLaboratorioService(
        IReservaLaboratorioRepository reservaLaboratorioRepository,
        IReservaNotebookRepository reservaNotebookRepository,
        IReservaSalaRepository reservaSalaRepository)
    {
        _reservaLaboratorioRepository = reservaLaboratorioRepository;
        _reservaNotebookRepository = reservaNotebookRepository;
        _reservaSalaRepository = reservaSalaRepository;
    }

    public async Task<bool> AddAsync(ReservaLaboratorio reservaLaboratorio)
    {
        bool isReserved = await _reservaLaboratorioRepository.IsLaboratorioReservedOnDateAsync(reservaLaboratorio.FkLaboratorio, reservaLaboratorio.DataReserva);
        if (isReserved)
        {
            return false;
        }

        bool hasExistingNotebookReservation = await _reservaNotebookRepository.IsNotebookReservedOnDateAsync(reservaLaboratorio.FkFuncionario, reservaLaboratorio.DataReserva);
        bool hasExistingSalaReservation = await _reservaSalaRepository.IsSalaReservedOnDateAsync(reservaLaboratorio.FkFuncionario, reservaLaboratorio.DataReserva);

        if (hasExistingNotebookReservation || hasExistingSalaReservation)
        {
            return false;
        }

        await _reservaLaboratorioRepository.AddAsync(reservaLaboratorio);
        return true;
    }

    public async Task<ReservaLaboratorioDto> GetByIdAsync(int id)
    {
        var reserva = await _reservaLaboratorioRepository.GetByIdAsync(id);
        if (reserva == null) return null;

        return new ReservaLaboratorioDto
        {
            Id = reserva.Id,
            FkFuncionario = reserva.FkFuncionario,
            FkLaboratorio = reserva.FkLaboratorio,
            DataReserva = reserva.DataReserva,
            NomeFuncionario = reserva.Funcionario?.Nome,
            NomeLaboratorio = reserva.Laboratorio?.Nome
        };
    }

    public async Task<IEnumerable<ReservaLaboratorioDto>> GetAllAsync()
    {
        var reservas = await _reservaLaboratorioRepository.GetAllAsync();
        return reservas.Select(reserva => new ReservaLaboratorioDto
        {
            Id = reserva.Id,
            FkFuncionario = reserva.FkFuncionario,
            FkLaboratorio = reserva.FkLaboratorio,
            DataReserva = reserva.DataReserva,
            NomeFuncionario = reserva.Funcionario?.Nome,
            NomeLaboratorio = reserva.Laboratorio?.Nome
        });
    }

    public async Task DeleteAsync(int id)
    {
        await _reservaLaboratorioRepository.DeleteAsync(id);
    }
}