using Microsoft.AspNetCore.Mvc;
using WebApiFindWorks.Models;
using WebApiFindWorks.Data;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(PedidoServico pedidoservico)
        {
            _dbContext.PedidoServico.Add(pedidoservico);
            await _dbContext.SaveChangesAsync();
            return Created("", pedidoservico);
        }

        

    }
}
