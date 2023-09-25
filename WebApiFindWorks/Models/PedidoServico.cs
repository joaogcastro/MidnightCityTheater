using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiFindWorks.Models
{
    public class PedidoServico
    {
        [Key]
        public int Id { get; set; }
        public int ProfissionalId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }

        public PedidoServico()
        {
            Id = 0;
            ProfissionalId = 0;
            UsuarioId = 0;
            DataPedido = DateTime.Now;
        }

        public PedidoServico(int id, int profissionalId, int usuarioId, DateTime dataPedido)
        {
            Id = id;
            ProfissionalId = profissionalId;
            UsuarioId = usuarioId;
            DataPedido = dataPedido;
        }
    }
}
