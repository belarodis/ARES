using Data.Repositories;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services;

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
        // Regra de Negócio 1: Verificar se o laboratório já está reservado na data
        bool isReserved = await _reservaLaboratorioRepository.IsLaboratorioReservedOnDateAsync(reservaLaboratorio.FkLaboratorio, reservaLaboratorio.DataReserva);
        if (isReserved)
        {
            return false;
        }

        // Regra de Negócio 2: Um usuário não pode reservar um laboratório e um notebook ou sala.
        // Verificamos se o funcionário já tem reserva de notebook OU sala no mesmo dia.
        bool hasExistingNotebookReservation = await _reservaNotebookRepository.HasUserReservedOnDateAsync(reservaLaboratorio.FkFuncionario, reservaLaboratorio.DataReserva);
        bool hasExistingSalaReservation = await _reservaSalaRepository.HasUserReservedOnDateAsync(reservaLaboratorio.FkFuncionario, reservaLaboratorio.DataReserva);
        
        if (hasExistingNotebookReservation || hasExistingSalaReservation)
        {
            return false;
        }

        // Se passar todas as validações, adicione a reserva
        await _reservaLaboratorioRepository.AddAsync(reservaLaboratorio);
        return true;
    }

    public async Task<ReservaLaboratorio> GetByIdAsync(int id)
    {
        return await _reservaLaboratorioRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ReservaLaboratorio>> GetAllAsync()
    {
        return await _reservaLaboratorioRepository.GetAllAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _reservaLaboratorioRepository.DeleteAsync(id);
    }
}