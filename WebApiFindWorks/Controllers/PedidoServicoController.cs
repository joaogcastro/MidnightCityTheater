using Microsoft.AspNetCore.Mvc;
using WebApiFindWorks.Models;
using WebApiFindWorks.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace WebApiFindWorks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoServicoController : ControllerBase
    {
        private readonly WebApiFindWorksDbContext _dbContext;

        public PedidoServicoController(WebApiFindWorksDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<PedidoServico>>> Listar()
        {
            var pedidoServicos = await _dbContext.PedidoServico.ToListAsync();
            return Ok(pedidoServicos);
        }

        [HttpGet("{id}")]
        [Route("buscar/{id}")]
        public async Task<ActionResult<PedidoServico>> Buscar(int id)
        {
            var pedidoServico = await _dbContext.PedidoServico.FindAsync(id);
            if (pedidoServico == null)
                return NotFound();
            return Ok(pedidoServico);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(PedidoServico pedidoservico)
        {
            _dbContext.PedidoServico.Add(pedidoservico);
            await _dbContext.SaveChangesAsync();
            return Created("", pedidoservico);
        }

        [HttpPut("{id}")]
        [Route("alterar/{id}")]
        public async Task<ActionResult> Alterar(int id, PedidoServico pedidoServico)
        {
            if (id != pedidoServico.Id)
            {
                return BadRequest();
            }

            var existingPedidoServico = await _dbContext.PedidoServico.FindAsync(id);

            if (existingPedidoServico == null)
            {
                return NotFound();
            }

            existingPedidoServico.ProfissionalId = pedidoServico.ProfissionalId;
            existingPedidoServico.UsuarioId = pedidoServico.UsuarioId;
            existingPedidoServico.DataPedido = pedidoServico.DataPedido;

            _dbContext.Entry(existingPedidoServico).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var pedidoservico = await _dbContext.PedidoServico.FindAsync(id);
            if (pedidoservico == null)
                return NotFound();

            _dbContext.PedidoServico.Remove(pedidoservico);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
