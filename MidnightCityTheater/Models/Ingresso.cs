using System.ComponentModel.DataAnnotations;

namespace MidnightCityTheater.Models
{
    public class Ingresso
    {
        [Key]
        public int IdIngresso { get; set; }
        [Required]
        public string TipoIngresso { get; set; }
        [Required]
        public string Data { get; set; }
        //public int IdFilme { get; set; }
        //public int IdSala { get; set; }
        //public int IdCliente{ get; set; }
        public string Preco { get; set; }

    }
}