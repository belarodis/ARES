using Api.Services.Interfaces;
using Data.Repositories.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.dtos;
using System.Linq;

namespace Api.Services.Implementations;

public class ReservaSalaService : IReservaSalaService
{
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly IReservaLaboratorioRepository _reservaLaboratorioRepository;

    public ReservaSalaService(IReservaSalaRepository reservaSalaRepository, IReservaLaboratorioRepository reservaLaboratorioRepository)
    {
        _reservaSalaRepository = reservaSalaRepository;
        _reservaLaboratorioRepository = reservaLaboratorioRepository;
    }

    public async Task<bool> AddAsync(ReservaSala reservaSala)
    {
        bool isReserved = await _reservaSalaRepository.IsSalaReservedOnDateAsync(reservaSala.FkSala, reservaSala.DataReserva);
        if (isReserved)
        {
            return false;
        }

        bool hasExistingLabReservation = await _reservaLaboratorioRepository.HasUserReservedOnDateAsync(reservaSala.FkFuncionario, reservaSala.DataReserva);
        if (hasExistingLabReservation)
        {
            return false;
        }

        await _reservaSalaRepository.AddAsync(reservaSala);
        return true;
    }

    public async Task<ReservaSalaDto> GetByIdAsync(int id)
    {
        var reserva = await _reservaSalaRepository.GetByIdAsync(id);
        if (reserva == null) return null;

        return new ReservaSalaDto
        {
            Id = reserva.Id,
            FkFuncionario = reserva.FkFuncionario,
            FkSala = reserva.FkSala,
            DataReserva = reserva.DataReserva,
            NomeFuncionario = reserva.Funcionario?.Nome,
            NumeroSala = reserva.Sala?.NumeroSala
        };
    }

    public async Task<IEnumerable<ReservaSalaDto>> GetAllAsync()
    {
        var reservas = await _reservaSalaRepository.GetAllAsync();
        return reservas.Select(reserva => new ReservaSalaDto
        {
            Id = reserva.Id,
            FkFuncionario = reserva.FkFuncionario,
            FkSala = reserva.FkSala,
            DataReserva = reserva.DataReserva,
            NomeFuncionario = reserva.Funcionario?.Nome,
            NumeroSala = reserva.Sala?.NumeroSala
        });
    }

    public async Task DeleteAsync(int id)
    {
        await _reservaSalaRepository.DeleteAsync(id);
    }
}