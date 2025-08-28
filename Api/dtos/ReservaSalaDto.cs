using System;

namespace Api.dtos
{
    public class ReservaSalaDto
    {
        public int Id { get; set; }
        public int FkFuncionario { get; set; }
        public int FkSala { get; set; }
        public DateOnly DataReserva { get; set; }
        public string NomeFuncionario { get; set; }
        public string NumeroSala { get; set; }
    }
}