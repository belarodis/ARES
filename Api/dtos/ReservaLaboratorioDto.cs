namespace Api.dtos
{
    public class ReservaLaboratorioDto
    {
        public int Id { get; set; }
        public int FkFuncionario { get; set; }
        public int FkLaboratorio { get; set; }
        public DateOnly DataReserva { get; set; }
        public string? NomeFuncionario { get; set; }
        public string? NomeLaboratorio { get; set; }
    }
}