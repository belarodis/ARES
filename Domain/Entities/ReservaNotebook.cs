using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain;

public class ReservaNotebook
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int FkFuncionario { get; set; }

    [Required]
    public int FkNotebook { get; set; }

    [Required]
    public DateOnly DataReserva { get; set; }

    // Navigation properties
    [ForeignKey("FkFuncionario")]
    public Funcionario Funcionario { get; set; }

    [ForeignKey("FkNotebook")]
    public Notebook Notebook { get; set; }
}