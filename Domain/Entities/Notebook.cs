using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Notebook
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(15)]
    public string NPatrimonio { get; set; }

    [Required]
    public DateOnly DataAquisicao { get; set; }

    [Required]
    [MaxLength(255)]
    public string Descricao { get; set; }

    // Navigation properties
    public ICollection<ReservaNotebook>? Reservas { get; set; }
}