using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }
        [Required]
        public string? Capacidade { get; set; } // Alterei o tipo para int para representar a capacidade de lugares.
        [Required]
        public string? TipoSala { get; set; }
        [Required]
        public double Preco { get; set; }
        //public Funcionario? Funcionario { get; set; } // RELAÇÃO DEFINIDA NO DBCONTEXT (está feito)
        //public int? IdFuncionario { get; set; }
        //public int? FilmeId { get; set; }
        //public Filme? Filme { get; set; }
    }
}