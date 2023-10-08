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

            if (_dbContext is null)
            {
            return NotFound("Database unavailable");
            }
            var salaList = await _dbContext.Sala.ToListAsync();
            return Ok(salaList);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Sala sala)
        {
            if (_dbContext is null) return NotFound("Database unavailable");
            _dbContext.Add(sala);
            await _dbContext.SaveChangesAsync();
            return Created("", sala);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Sala>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound("Database unavailable");
            var room = await _dbContext.Sala.FindAsync(id);
            if (room is null) return UnprocessableEntity("No entities were found with this ID");
            return room;
        }

        [HttpPut()]
        [Route("alterar")]
         public async Task<ActionResult> Alterar(Sala sala)
        {
        if (_dbContext is null)
            return NotFound("Database unavailable");

        var existingSala = await _dbContext.Sala.FindAsync(sala.IdSala);

        if (existingSala is null)
            return UnprocessableEntity("No entities were found with this ID");

        if (sala.Capacidade != "string")
        {
            existingSala.Capacidade = sala.Capacidade;
        }

        if (sala.TipoSala != "string")
        {
            existingSala.TipoSala = sala.TipoSala;
        }


        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingSala).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound("Database unavailable");
            var salaDel = await _dbContext.Sala.FindAsync(id);
            if (salaDel is null) return UnprocessableEntity("No entities were found with this ID");
            _dbContext.Sala.Remove(salaDel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
