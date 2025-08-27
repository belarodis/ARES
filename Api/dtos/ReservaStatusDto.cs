using System;

namespace Api.dtos;

public class ReservaStatusDto
{
    public DateOnly DataReserva { get; set; }
    public string TipoRecurso { get; set; }
    public string NomeRecurso { get; set; }
    public string FuncionarioNome { get; set; }
}