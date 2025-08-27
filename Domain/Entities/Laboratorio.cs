using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Laboratorio
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nome { get; set; }

    [Required]
    public int QtdComputadores { get; set; }

    [MaxLength(255)]
    public string ConfigComputadores { get; set; }

    public ICollection<ReservaLaboratorio>? Reservas { get; set; }
}