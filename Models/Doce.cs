using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Doce
{
    [Key]
    public int IdDoce { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public double Preco { get; set; }
}