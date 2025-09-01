using Api.Services.Interfaces;
using Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.dtos;

namespace Api.Controllers;

[ApiController]
[Route("api/status")]
public class StatusController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusController(IStatusService statusService)
    {
        _statusService = statusService;
    }

    // GET api/status?startDate=2025-08-01&endDate=2025-08-31
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaStatusDto>>> Get([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
    {
        if (startDate > endDate)
        {
            return BadRequest("A data de início não pode ser maior que a data de fim.");
        }
        
        var status = await _statusService.GetReservationsByPeriodAsync(startDate, endDate);
        return Ok(status);
    }

[HttpGet("dias-mais-ocupados")]
public async Task<ActionResult<IEnumerable<BusiestDayDto>>> GetBusiestDays([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
{
    if (startDate > endDate)
    {
        return BadRequest("A data de início não pode ser maior que a data de fim.");
    }
    
    var busiestDays = await _statusService.GetBusiestDaysAsync(startDate, endDate);
    return Ok(busiestDays);
}
}