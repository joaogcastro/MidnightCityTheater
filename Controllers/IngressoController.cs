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

            if (_dbContext is null)
            {
            return NotFound("Database unavailable");
            }

            var ingressoList = await _dbContext.Ingresso.ToListAsync();
            return Ok(ingressoList);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Ingresso ingresso)
        {
            if (_dbContext is null) return NotFound("Database unavailable");
            _dbContext.Add(ingresso);
            await _dbContext.SaveChangesAsync();
            return Created("", ingresso);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Ingresso>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound("Database unavailable");
            var ticket = await _dbContext.Ingresso.FindAsync(id);
            if (ticket is null) return UnprocessableEntity("No entities were found with this ID");
            return ticket;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Ingresso ingresso)
        {
        if (_dbContext is null)
            return NotFound("Database unavailable");

        var existingIngresso = await _dbContext.Ingresso.FindAsync(ingresso.IdIngresso);

        if (existingIngresso is null)
            return UnprocessableEntity("No entities were found with this ID");

        if (ingresso.Data != "string")
        {
            existingIngresso.Data = ingresso.Data;
        }

        if (ingresso.TipoIngresso != "string")
        {
            existingIngresso.TipoIngresso = ingresso.TipoIngresso;
        }

        if (ingresso.Preco != "string")
        {
            existingIngresso.Preco = ingresso.Preco;
        }

        /*if (ingresso.VendaId != "int")
        {
            existingIngresso.VendaId = ingresso.VendaId;
        }

        if (ingresso.Venda != "venda")
        {
            existingIngresso.Venda = ingresso.Venda;
        }
        
        (♠ Parte comentada por não saber como resolver :D)

        */


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
            if (_dbContext is null) return NotFound("Database unavailable");
            var ingressoDel = await _dbContext.Ingresso.FindAsync(id);
            if (ingressoDel is null) return UnprocessableEntity("No entities were found with this ID");
            _dbContext.Ingresso.Remove(ingressoDel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}