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
            var filmeList = await _dbContext.Filme.ToListAsync();
            return Ok(filmeList);
        }  

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Filme filme)
    {
        if(_dbContext is null) return NotFound();
        _dbContext.Add(filme);
        await _dbContext.SaveChangesAsync();
        return Created("", filme);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Filme>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            return NotFound();
        var movie = await _dbContext.Filme.FindAsync(id);
        if (movie is null)
            return NotFound();
        return movie;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Filme filme)
    {
        if (_dbContext is null)
            return NotFound();
        var existingFilme = await _dbContext.Filme.FindAsync(filme.IdFilme);

        if (existingFilme is null)
            return NotFound();

        if (!string.IsNullOrEmpty(filme.NomeFilme))
        {
            existingFilme.NomeFilme = filme.NomeFilme;
        }

        if (!string.IsNullOrEmpty(filme.Duracao))
        {
            existingFilme.Duracao = filme.Duracao;
        }

        if (!string.IsNullOrEmpty(filme.Classificacao))
        {
            existingFilme.Classificacao = filme.Classificacao;
        }

        if (!string.IsNullOrEmpty(filme.Diretor))
        {
            existingFilme.Diretor = filme.Diretor;
        }

        if (!string.IsNullOrEmpty(filme.Categoria))
        {
            existingFilme.Categoria = filme.Categoria;
        }

        _dbContext.Entry(existingFilme).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound();
        var filmedel = await _dbContext.Filme.FindAsync(id);
        if (filmedel is null) return NotFound();
        _dbContext.Filme.Remove(filmedel);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
 
}

}