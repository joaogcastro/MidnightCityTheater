using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApiFindWorks.Controllers{

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{

    private APIDbContext _dbContext;

    public FilmeController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Filme>>> Listar()
        {

            if(_dbContext is null)
            {
                return NotFound("Database unavailable");
            }

            var filmeList = await _dbContext.Filme.ToListAsync();
            return Ok(filmeList);
        }  

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Filme filme)
    {
        if (_dbContext is null) return NotFound("Database unavailable");
        _dbContext.Add(filme);
        await _dbContext.SaveChangesAsync();
        return Created("", filme);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Filme>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound("Database unavailable");
        var movie = await _dbContext.Filme.FindAsync(id);
        if (movie is null)
            return UnprocessableEntity("No entities were found with this ID");
        return movie;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Filme filme)
    {
        if (_dbContext is null)
            return NotFound("Database unavailable");

        var existingFilme = await _dbContext.Filme.FindAsync(filme.IdFilme);

        if (existingFilme is null)
            return UnprocessableEntity("No entities were found with this ID");

        if (filme.NomeFilme != "string")
        {
            existingFilme.NomeFilme = filme.NomeFilme;
        }

        if (filme.Duracao != "string")
        {
            existingFilme.Duracao = filme.Duracao;
        }

        if (filme.Classificacao != "string")
        {
            existingFilme.Classificacao = filme.Classificacao;
        }

        if (filme.Diretor != "string")
        {
            existingFilme.Diretor = filme.Diretor;
        }

        if (filme.Categoria != "string")
        {
            existingFilme.Categoria = filme.Categoria;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingFilme).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound("Database unavailable");
        var filmedel = await _dbContext.Filme.FindAsync(id);
        if (filmedel is null) return UnprocessableEntity("No entities were found with this ID");
        _dbContext.Filme.Remove(filmedel);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
 
}

}