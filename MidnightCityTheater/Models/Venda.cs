using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Venda
{
    [Key]
    public int IdVenda { get; set; }

    // Relacionamento um-para-um com Cliente
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    // Relacionamento um-para-um com Ingresso
    public int IngressoId { get; set; }
    public Ingresso Ingresso { get; set; }

    // Relacionamento um-para-um com Snack
    public int SnackId { get; set; }
    public Snack Snack { get; set; }
}