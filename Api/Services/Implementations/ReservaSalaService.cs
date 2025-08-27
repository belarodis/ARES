using Data.Repositories;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

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

        // Regra de Negócio 2: Um usuário pode reservar uma sala E um notebook, mas não qualquer outra combinação.
        // A lógica é verificar se o funcionário já tem uma reserva de laboratório na mesma data, pois essa combinação não é permitida.
        bool hasExistingLabReservation = await _reservaLaboratorioRepository.HasUserReservedOnDateAsync(reservaSala.FkFuncionario, reservaSala.DataReserva);
        if (hasExistingLabReservation)
        {
            return false;
        }

        // Se passar todas as validações, adicione a reserva
        await _reservaSalaRepository.AddAsync(reservaSala);
        return true;
    }

    public async Task<ReservaSala> GetByIdAsync(int id)
    {
        return await _reservaSalaRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ReservaSala>> GetAllAsync()
    {
        return await _reservaSalaRepository.GetAllAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _reservaSalaRepository.DeleteAsync(id);
    }
}