using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }
        public Funcionario Funcionario { get; set; } //FAÇA A RELAÇÃO NO DBCONTEXT
        [Required]
        public string Capacidade { get; set; }
        public string? TipoSala { get; set; }

        //public int IdFilme { get; set; }

    }
}