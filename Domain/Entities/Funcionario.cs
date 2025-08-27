using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Domain;

public class Funcionario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(15)]
    public string Matricula { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(50)]
    public string Cargo { get; set; }

    [Required]
    public DateOnly DataAdmissao { get; set; }

    public ICollection<ReservaLaboratorio>? ReservasLaboratorio { get; set; }
    public ICollection<ReservaNotebook>? ReservasNotebook { get; set; }
    public ICollection<ReservaSala>? ReservasSala { get; set; }
}

