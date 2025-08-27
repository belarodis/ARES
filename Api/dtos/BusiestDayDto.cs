using System;

namespace Api.DTOs;

public class BusiestDayDto
{
    public DateOnly Data { get; set; }
    public int TotalReservas { get; set; }
}