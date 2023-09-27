using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Doce
{
    [Key]
    public int IdDoce { get; set; }
    [Required]
    public string Nome { get; set; }
    public int SnackId { get; set; }
    public Snack Snack { get; set; }
}