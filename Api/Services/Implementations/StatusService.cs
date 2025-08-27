using Data.Repositories;
using Api.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class StatusService : IStatusService
{
    private readonly IReservaNotebookRepository _notebookRepo;
    private readonly IReservaSalaRepository _salaRepo;
    private readonly IReservaLaboratorioRepository _laboratorioRepo;

    public StatusService(IReservaNotebookRepository notebookRepo, IReservaSalaRepository salaRepo, IReservaLaboratorioRepository laboratorioRepo)
    {
        _notebookRepo = notebookRepo;
        _salaRepo = salaRepo;
        _laboratorioRepo = laboratorioRepo;
    }

    public async Task<IEnumerable<ReservaStatusDto>> GetReservationsByPeriodAsync(DateOnly startDate, DateOnly endDate)
    {
        var allNotebookReservations = await _notebookRepo.GetAllAsync();
        var allSalaReservations = await _salaRepo.GetAllAsync();
        var allLaboratorioReservations = await _laboratorioRepo.GetAllAsync();

        var notebookReservationsDto = allNotebookReservations
            .Where(r => r.DataReserva >= startDate && r.DataReserva <= endDate)
            .Select(r => new ReservaStatusDto
            {
                DataReserva = r.DataReserva,
                TipoRecurso = "Notebook",
                NomeRecurso = r.Notebook.NPatrimonio,
                FuncionarioNome = r.Funcionario.Nome
            });

        var salaReservationsDto = allSalaReservations
            .Where(r => r.DataReserva >= startDate && r.DataReserva <= endDate)
            .Select(r => new ReservaStatusDto
            {
                DataReserva = r.DataReserva,
                TipoRecurso = "Sala",
                NomeRecurso = r.Sala.NumeroSala,
                FuncionarioNome = r.Funcionario.Nome
            });

        var laboratorioReservationsDto = allLaboratorioReservations
            .Where(r => r.DataReserva >= startDate && r.DataReserva <= endDate)
            .Select(r => new ReservaStatusDto
            {
                DataReserva = r.DataReserva,
                TipoRecurso = "Laboratorio",
                NomeRecurso = r.Laboratorio.Nome,
                FuncionarioNome = r.Funcionario.Nome
            });

        return notebookReservationsDto
            .Concat(salaReservationsDto)
            .Concat(laboratorioReservationsDto)
            .OrderBy(r => r.DataReserva)
            .ToList();
    }
}