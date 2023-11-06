using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }
        public Funcionario? Funcionario { get; set; } //FAÇA A RELAÇÃO NO DBCONTEXT (TA FEITO)
        [Required]
        public string? Capacidade { get; set; }
        public string? TipoSala { get; set; }

        public List<Filme>? Filmes {get; set;}

    }
}