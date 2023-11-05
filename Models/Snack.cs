using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Snack
{
    [Key]
    public int IdSnack { get; set; }
    public List<Pipoca>? Pipocas { get; set; }
    public List<Bebida>? Bebidas { get; set; }
    public List<Doce>? Doces { get; set; }
    public decimal PrecoTotal { get; set; }
}