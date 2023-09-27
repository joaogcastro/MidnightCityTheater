using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Snack
{
    [Key]
    public int IdSnack { get; set; }
    public List<Pipoca>? Pipoca { get; set; }
    public List<Bebida>? Bebida { get; set; }
    public List<Doce>? Doce { get; set; }
    /*public int VendaId { get; set; }
    public Venda Venda { get; set; }*/
}