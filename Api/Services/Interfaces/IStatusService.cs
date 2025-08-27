using Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services;

public interface IStatusService
{
    Task<IEnumerable<ReservaStatusDto>> GetReservationsByPeriodAsync(DateOnly startDate, DateOnly endDate);
}