using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Filme
    {
        [Key]
        public int IdFilme { get; set; }

        [Required]
        public string? NomeFilme { get; set; }

        [Required]
        public string? Duracao { get; set; }

        public string? Classificacao { get; set; }

        public string? Diretor { get; set; }

        public string? Categoria { get; set; }

        public int SalaId { get; set; } // Adicione a propriedade SalaId como chave estrangeira

        public Sala? Sala { get; set; } // Adicione a propriedade de navegação para a sala
    }
}