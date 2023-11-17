using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MidnightCityTheater.Utils;

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
            return NotFound(ErrorResponse.DBisUnavailable);
            }
            var salaList = await _dbContext.Sala.ToListAsync();
            return Ok(salaList);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Sala sala)
        {
            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
            if (sala.Capacidade is null || sala.TipoSala is null || sala.Preco == 0) return BadRequest(ErrorResponse.AttributeisNull);
            _dbContext.Add(sala);
            await _dbContext.SaveChangesAsync();
            return Created("", sala);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Sala>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
            var room = await _dbContext.Sala.FindAsync(id);
            if (room is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
            return room;
        }

        [HttpPut()]
        [Route("alterar")]
         public async Task<ActionResult> Alterar(Sala sala)
        {
        if (_dbContext is null)
            return NotFound(ErrorResponse.DBisUnavailable);
        if (sala is null) return BadRequest(ErrorResponse.ObjectisNull);

        var existingSala = await _dbContext.Sala.FindAsync(sala.IdSala);

        if (existingSala is null)
            return UnprocessableEntity(ErrorResponse.EntityNotFound);

        if (sala.Capacidade != "string" && sala.Capacidade != null)
        {
            existingSala.Capacidade = sala.Capacidade;
        }

        if (sala.TipoSala != "string" && sala.TipoSala != null)
        {
            existingSala.TipoSala = sala.TipoSala;
        }

        if (sala!.Preco != 0)
        {
            existingSala.Preco = sala.Preco;
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
            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
            var salaDel = await _dbContext.Sala.FindAsync(id);
            if (salaDel is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
            _dbContext.Sala.Remove(salaDel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
