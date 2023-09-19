using System.ComponentModel.DataAnnotations;
namespace WebApiFindWorks.Models;

public class Profissional
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Profissao { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public double ValorHora { get; set; }
    public double Distancia { get; set; }

    public Profissional()
    {
        Id = 0;
        Nome = null;
        Profissao = null;
        Email = null;
        Telefone = null;
        ValorHora = 0.0;
        Distancia = 0.0;
    }
    
    public Profissional(int id, string nome, string profissao, string email, string telefone, double valorHora, double distancia)
    {
        Id = id;
        Nome = nome;
        Profissao = profissao;
        Email = email;
        Telefone = telefone;
        ValorHora = valorHora;
        Distancia = distancia;
    }
}