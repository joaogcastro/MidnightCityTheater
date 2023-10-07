using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApiFindWorks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnackController : ControllerBase
    {
        private APIDbContext _dbContext;

        public SnackController(APIDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Snack>>> Listar()
        {
            if (_dbContext is null)
            {
                return NotFound();
            }
            return await _dbContext.Snack.ToListAsync();
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Snack snack)
        {
            if (_dbContext is null)
                return NotFound();
            _dbContext.Add(snack);
            await _dbContext.SaveChangesAsync();
            return Created("", snack);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Snack>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null)
                return NotFound();
            var snack = await _dbContext.Snack.FindAsync(id);
            if (snack is null)
                return NotFound();
            return snack;
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Snack snack)
        {
            if (_dbContext is null)
                return NotFound();

            // Find the existing record by ID (or another primary key) of the snack
            var existingSnack = await _dbContext.Snack.FindAsync(snack.IdSnack);

            if (existingSnack is null)
                return NotFound();

            // Update only the fields provided in the snack object
            // Modify these conditions according to your actual model properties
            if (snack.Pipoca != null)
            {
                existingSnack.Pipoca = snack.Pipoca;
            }

            if (snack.Bebida != null)
            {
                existingSnack.Bebida = snack.Bebida;
            }

            if (snack.Doce != null)
            {
                existingSnack.Doce = snack.Doce;
            }

            // Mark the record as modified in the EF context
            _dbContext.Entry(existingSnack).State = EntityState.Modified;

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_dbContext is null) return NotFound();
            var snack = await _dbContext.Snack.FindAsync(id);
            if (snack is null) return NotFound();
            _dbContext.Snack.Remove(snack);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}