using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Ingresso
    {
        [Key]
        public int IdIngresso { get; set; }
        [Required]
        public string? TipoIngresso { get; set; }
        [Required]
        public double? PrecoIng { get; set; }
        [Required]
        public DateTime Data {get; set;}
        public Filme? Filme { get; set; }
    }
}