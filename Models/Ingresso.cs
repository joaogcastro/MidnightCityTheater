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
        public string? Data { get; set; }

        // Relações com Filme e Sala
        public int FilmeId { get; set; }
        public Filme? Filme { get; set; }
        
        public int SalaId { get; set; }
        public Sala? Sala { get; set; }

        public string? Preco { get; set; }
        
        public int VendaId { get; set; }
        public Venda? Venda { get; set; }
    }
}