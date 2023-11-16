using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Filme
    {
        [Key]
        public int IdFilme { get; set; }

        [Required]
        public string? nomeFilme { get; set; }

        [Required]
        public string? Duracao { get; set; }

        public string? Classificacao { get; set; }

        public string? Diretor { get; set; }

        public string? Categoria { get; set; }
        public int? IdSala { get; set; }
        public Sala? Sala { get; set; }
    }
}