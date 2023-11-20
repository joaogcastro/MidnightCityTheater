using System.ComponentModel.DataAnnotations;
namespace MidnightCityTheater.Models;

public class Venda
{
    [Key]
    public int IdVenda { get; set; }
    public DateTime Data { get; set; }
    public Cliente? Cliente { get; set; }
    public Ingresso? Ingresso { get; set; }
    public List<Filme>? Filmes { get; set; }
    public Snack? Snack { get; set; }
    public double PrecoTotalVenda { get; set; }
}