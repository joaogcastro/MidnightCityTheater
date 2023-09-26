using System.ComponentModel.DataAnnotations;
namespace MidnightCityTheater.Models;

public class Cliente
{
    [Key] // Define a chave primária
    public int IdCliente { get; set; }
    [Required] //Not null
    [StringLength(11)] //Define o tamanho maximo da string para 11
    public string CPF { get; set; }
    [Required] //Not null
    public string Nome { get; set; }
    public string? Email { get; set; } //? significa que pode ser nulo
    [StringLength(11)] //Define o tamanho maximo da string para 11
    public string? Telefone { get; set;} //? significa que pode ser nulo
}