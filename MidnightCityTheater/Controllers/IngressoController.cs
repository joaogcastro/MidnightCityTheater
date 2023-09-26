using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiFindWorks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngressoController : ControllerBase
    {
        private APIDbContext _dbContext;

        public IngressoController(APIDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Ingresso>>> Listar()
        {
            var ingressoList = await _dbContext.Ingresso.ToListAsync();
            return Ok(ingressoList);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Ingresso ingresso)
        {
            if (_dbContext is null) return NotFound();
            _dbContext.Add(ingresso);
            await _dbContext.SaveChangesAsync();
            return Created("", ingresso);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Ingresso>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound();
            var ticket = await _dbContext.Ingresso.FindAsync(id);
            if (ticket is null) return NotFound();
            return ticket;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Ingresso ingresso)
        {
            if (_dbContext is null) return NotFound();
            var existingIngresso = await _dbContext.Ingresso.FindAsync(ingresso.IdIngresso);

            if (existingIngresso is null) return NotFound();

            if (!string.IsNullOrEmpty(ingresso.TipoIngresso))
            {
                existingIngresso.TipoIngresso = ingresso.TipoIngresso;
            }

            if (!string.IsNullOrEmpty(ingresso.Preco))
            {
                existingIngresso.Preco = ingresso.Preco;
            }

            _dbContext.Entry(existingIngresso).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound();
            var ingressoDel = await _dbContext.Ingresso.FindAsync(id);
            if (ingressoDel is null) return NotFound();
            _dbContext.Ingresso.Remove(ingressoDel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}