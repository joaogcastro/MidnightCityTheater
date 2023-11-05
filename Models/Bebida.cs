using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Bebida
{
    [Key]
    public int IdBebida { get; set; }
    [Required]
    public string? Sabor { get; set; }
    [Required]
    public string? Tamanho { get; set; }
    [Required]
    public double Preco { get; set; }
}