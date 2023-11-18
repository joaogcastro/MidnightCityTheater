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

            if (_dbContext is null)
            {
            return NotFound(ErrorResponse.DBisUnavailable);
            }

            var ingressoList = await _dbContext.Ingresso.ToListAsync();
            return Ok(ingressoList);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Ingresso ingresso)
        {
            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
            if (ingresso.TipoIngresso is null || ingresso.PrecoIng is null) return BadRequest(ErrorResponse.AttributeisNull);
            _dbContext.Add(ingresso);
            await _dbContext.SaveChangesAsync();
            return Created("", ingresso);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Ingresso>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
            var ticket = await _dbContext.Ingresso.FindAsync(id);
            if (ticket is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
            return ticket;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Ingresso ingresso)
        {
        if (_dbContext is null)
            return NotFound(ErrorResponse.DBisUnavailable);
        if (ingresso is null) return BadRequest(ErrorResponse.ObjectisNull);

        var existingIngresso = await _dbContext.Ingresso.FindAsync(ingresso.IdIngresso);

        if (existingIngresso is null)
            return UnprocessableEntity(ErrorResponse.EntityNotFound);

        if (ingresso.TipoIngresso != "string" && ingresso.TipoIngresso != null)
        {
            existingIngresso.TipoIngresso = ingresso.TipoIngresso;
        }

        if (ingresso!.PrecoIng != 0)
        {
            existingIngresso.PrecoIng = ingresso.PrecoIng;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingIngresso).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
            var ingressoDel = await _dbContext.Ingresso.FindAsync(id);
            if (ingressoDel is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
            _dbContext.Ingresso.Remove(ingressoDel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}