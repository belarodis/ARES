using Api.dtos;
using Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Interfaces;

public interface IStatusService
{
    Task<IEnumerable<ReservaStatusDto>> GetReservationsByPeriodAsync(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<BusiestDayDto>> GetBusiestDaysAsync(DateOnly startDate, DateOnly endDate);
}