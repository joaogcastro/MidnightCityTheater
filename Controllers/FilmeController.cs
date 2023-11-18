using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFindWorks.Controllers
{
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
            /*if (_dbContext is null)
                return NotFound(ErrorResponse.DBisUnavailable);

            var filmeList = await _dbContext.Filme.ToListAsync();
            return Ok(filmeList);*/

            if (_dbContext is null)
            return NotFound(ErrorResponse.DBisUnavailable);

        var filmes = await _dbContext.Filme
            .Include(v => v.Sala)
            .ToListAsync();
            

        return filmes;

            
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Filme>> Buscar([FromRoute] int id)
        {
            if (_dbContext is null)
            {
                return NotFound(ErrorResponse.DBisUnavailable);
            }

            var filme = await _dbContext.Filme
                .Include(f => f.Sala) // Inclua a relação com Sala diretamente no Filme
                .FirstOrDefaultAsync(f => f.IdFilme == id);

            if (filme == null)
            {
                return UnprocessableEntity(ErrorResponse.EntityNotFound);
            }

            return filme;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Filme filme)
        {
            if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
            if (filme.nomeFilme is null || filme.Duracao is null || filme.Classificacao is null || filme.Diretor is null || filme.Categoria is null) return BadRequest(ErrorResponse.AttributeisNull);
            _dbContext.Add(filme);
            await _dbContext.SaveChangesAsync();
            return Created("", filme);
        }

        [HttpPut("alterar")]
        public async Task<ActionResult> Alterar(Filme filme)
        {
        if (_dbContext is null)
            return NotFound(ErrorResponse.DBisUnavailable);
        
        if (filme is null)
            return BadRequest(ErrorResponse.ObjectisNull);

        var existingFilme = await _dbContext.Filme.FindAsync(filme.IdFilme);

        if (existingFilme is null)
            return UnprocessableEntity(ErrorResponse.EntityNotFound);

        if (!string.IsNullOrEmpty(filme.nomeFilme))
        {
            existingFilme.nomeFilme = filme.nomeFilme;
        }

        if (!string.IsNullOrEmpty(filme.Duracao))
        {
            existingFilme.Duracao = filme.Duracao;
        }

        /*if (filme.Duracao != "string" && filme.Duracao != null)
        {
            existingFilme.Duracao = filme.Duracao;
        }*/

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



        _dbContext.Entry(existingFilme).State = EntityState.Modified;


        await _dbContext.SaveChangesAsync();

        return Ok();
    }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_dbContext is null)
                return NotFound(ErrorResponse.DBisUnavailable);

            // Verifique se o filme existe
            var filmedel = await _dbContext.Filme.FindAsync(id);
            if (filmedel is null)
                return UnprocessableEntity(ErrorResponse.EntityNotFound);

            _dbContext.Filme.Remove(filmedel);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}