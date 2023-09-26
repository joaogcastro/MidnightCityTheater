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
    public class SalaController : ControllerBase
    {
        private APIDbContext _dbContext;

        public SalaController(APIDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Sala>>> Listar()
        {
            var salaList = await _dbContext.Sala.ToListAsync();
            return Ok(salaList);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Sala sala)
        {
            if (_dbContext is null) return NotFound();
            _dbContext.Add(sala);
            await _dbContext.SaveChangesAsync();
            return Created("", sala);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Sala>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound();
            var room = await _dbContext.Sala.FindAsync(id);
            if (room is null) return NotFound();
            return room;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Sala sala)
        {
            if (_dbContext is null) return NotFound();
            var existingSala = await _dbContext.Sala.FindAsync(sala.IdSala);

            if (existingSala is null) return NotFound();

            if (!string.IsNullOrEmpty(sala.Capacidade))
            {
                existingSala.Capacidade = sala.Capacidade;
            }

            if (!string.IsNullOrEmpty(sala.TipoSala))
            {
                existingSala.TipoSala = sala.TipoSala;
            }

            _dbContext.Entry(existingSala).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound();
            var salaDel = await _dbContext.Sala.FindAsync(id);
            if (salaDel is null) return NotFound();
            _dbContext.Sala.Remove(salaDel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
