using System;

namespace Api.dtos
{
    public class ReservaNotebookDto
    {
        public int Id { get; set; }
        public int FkFuncionario { get; set; }
        public int FkNotebook { get; set; }
        public DateOnly DataReserva { get; set; }
        public string? NomeFuncionario { get; set; }
        public string? NomeNotebook { get; set; }
    }
}