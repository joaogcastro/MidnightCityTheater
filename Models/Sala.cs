using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }

        [Required]
        public string? Capacidade { get; set; }

        public string? TipoSala { get; set; }
    }
}