using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Sala
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(4)]
    public string NumeroSala { get; set; }

    [Required]
    public bool TemProjetor { get; set; }

    // Navigation properties
    public ICollection<ReservaSala> Reservas { get; set; }
}