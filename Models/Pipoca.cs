using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;
public class Pipoca
{
    [Key]
    public int IdPipoca { get; set; }
    [Required]
    public string? Sabor { get; set; }
    [Required]
    public string? Tamanho { get; set; }
    [Required]
    public double Preco { get; set; }
    /*public int SnackId { get; set; }
    public Snack Snack { get; set; }*/
}