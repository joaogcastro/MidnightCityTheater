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
        //public int? IdFilme { get; set; }
        public Filme? Filme { get; set; }
        //public int? IdSala { get; set; }
        public Sala? Sala { get; set; }
        public string? Preco { get; set; }
        public int VendaId { get; set; }
        public Venda? Venda { get; set; }

    }
}