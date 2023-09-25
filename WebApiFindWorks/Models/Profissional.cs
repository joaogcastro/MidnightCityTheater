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
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public double ValorHora { get; set; }
    public double DistanciaDoCentro { get; set; }
    public ICollection<Rating>? Ratings { get; set; }

    public Profissional()
    {
        Id = 0;
        Nome = null;
        Profissao = null;
        Email = null;
        Telefone = null;
        Cidade = null;
        Bairro = null;
        ValorHora = 0.0;
        DistanciaDoCentro = 0.0;
        Ratings = null;
    }
    
    public Profissional(int id, string nome, string profissao, string email, string telefone, string cidade, string bairro, double valorHora, double distancia)
    {
        Id = id;
        Nome = nome;
        Profissao = profissao;
        Email = email;
        Telefone = telefone;
        Cidade = cidade;
        Bairro = bairro;
        ValorHora = valorHora;
        DistanciaDoCentro = distancia;
    }
}