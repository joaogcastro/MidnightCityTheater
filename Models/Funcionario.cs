using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models;

public class Funcionario
{
    [Key] // Indica que IdFuncionario é a chave primária
    public int IdFuncionario { get; set; }

    [Required] // Not null
    public string? CPFfunc { get; set; }

    [Required] // Not null
    public string? NomeFunc { get; set; }

    public string? EmailFunc { get; set; } // Pode ser nulo

    public string? TelefoneFunc { get; set; } // Pode ser nulo
}
