using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Venda
{
    [Key]
    public int IdVenda { get; set; }
    public DateTime Data {get; set;}

    // Relacionamento um-para-um com Cliente
    public Cliente? Cliente { get; set; }

    // Relacionamento um-para-um com Ingresso
    public Ingresso? Ingresso { get; set; }

    public List<Filme>? Filmes { get; set; }

    // Relacionamento um-para-um com Snack
    public Snack? Snack { get; set; }

    public double PrecoTotalVenda {get; set;}
}
