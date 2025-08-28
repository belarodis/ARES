using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain;

public class ReservaLaboratorio : IHasDateOnly
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int FkFuncionario { get; set; }

    [Required]
    public int FkLaboratorio { get; set; }

    [Required]
    public DateOnly DataReserva { get; set; }

    // Navigation properties
    [ForeignKey("FkFuncionario")]
    public Funcionario Funcionario { get; set; }

    [ForeignKey("FkLaboratorio")]
    public Laboratorio Laboratorio { get; set; }
}