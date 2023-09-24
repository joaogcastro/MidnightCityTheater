using System.ComponentModel.DataAnnotations;
namespace WebApiFindWorks.Models;
public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string? NomeUsuario { get; set; }
    public string? Senha { get; set; }

    public Usuario()
    {
        Id = 0;
        NomeUsuario = null;
        Senha = null;
    }

    public Usuario(int id, string nomeUsuario, string senha, Profissional profissional)
    {
        Id = id;
        NomeUsuario = nomeUsuario;
        Senha = senha;
    }
}