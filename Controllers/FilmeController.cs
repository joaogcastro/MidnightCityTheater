using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Utils;
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

            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);

            var filmeList = await _dbContext.Filme.ToListAsync();
            return Ok(filmeList);
        }  

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Filme filme)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (filme.NomeFilme is null || filme.Duracao is null || filme.Diretor is null || filme.Classificacao is null || filme.Categoria is null) return BadRequest(ErrorResponse.AttributeisNull);
        _dbContext.Add(filme);
        await _dbContext.SaveChangesAsync();
        return Created("", filme);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Filme>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var movie = await _dbContext.Filme.FindAsync(id);
        if (movie is null)
            return UnprocessableEntity(ErrorResponse.EntityNotFound);
        return movie;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Filme filme)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (filme is null) return BadRequest(ErrorResponse.ObjectisNull);

        var existingFilme = await _dbContext.Filme.FindAsync(filme.IdFilme);

        if (existingFilme is null)return UnprocessableEntity(ErrorResponse.EntityNotFound);

        if (filme.NomeFilme != "string" && filme.NomeFilme != null)
        {
            existingFilme.NomeFilme = filme.NomeFilme;
        }

        if (filme.Duracao != "string" && filme.Duracao != null)
        {
            existingFilme.Duracao = filme.Duracao;
        }

        if (filme.Classificacao != "string" && filme.Classificacao != null)
        {
            existingFilme.Classificacao = filme.Classificacao;
        }

        if (filme.Diretor != "string" && filme.Diretor != null)
        {
            existingFilme.Diretor = filme.Diretor;
        }

        if (filme.Categoria != "string" && filme.Categoria != null)
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
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var filmedel = await _dbContext.Filme.FindAsync(id);
        if (filmedel is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        _dbContext.Filme.Remove(filmedel);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
 
}

}