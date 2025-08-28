using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain;

public class ReservaSala : IHasDateOnly
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int FkFuncionario { get; set; }

    [Required]
    public int FkSala { get; set; }

    [Required]
    public DateOnly DataReserva { get; set; }

    // Navigation properties
    [ForeignKey("FkFuncionario")]
    public Funcionario Funcionario { get; set; }

    [ForeignKey("FkSala")]
    public Sala Sala { get; set; }
}