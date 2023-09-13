namespace PedreiragemBR.Models;
using System.ComponentModel.DataAnnotations;

public class Carro{
    [Key] //definindo a Primary Key
    public string? Placa {get;set;}
    public string? Descricao {get;set;}
}