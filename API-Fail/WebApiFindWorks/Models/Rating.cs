using System.ComponentModel.DataAnnotations;
namespace WebApiFindWorks.Models;

public class Rating
{
    [Key]
    public int Id { get; set; }
    public int Value { get; set; }
    public string? Comentario { get; set; }
    public int ProfissionalId { get; set; }
   

    public Rating()
    {
        Id = 0;
        Value = 0;
        Comentario = null;
        ProfissionalId = 0;
    }

    public Rating(int id, int value, string comentario, int profissionalId)
    {
        Id = id;
        Value = value;
        Comentario = comentario;
        ProfissionalId = profissionalId;
    }
}