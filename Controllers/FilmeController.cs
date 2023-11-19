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
            .Include(f => f.Sala)
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
            if (_dbContext is null)
                return NotFound(ErrorResponse.DBisUnavailable);

            if (filme.nomeFilme is null || filme.Duracao is null || filme.Classificacao is null || filme.Diretor is null || filme.Categoria is null)
                return BadRequest(ErrorResponse.AttributeisNull);

            // Verifica se a sala existe
            if (filme.Sala != null)
            {
                var existingSala = await _dbContext.Sala.FindAsync(filme.Sala.IdSala);

                if (existingSala != null)
                {
                    // Atualiza as propriedades da sala existente com os valores da sala do filme
                    _dbContext.Entry(existingSala).CurrentValues.SetValues(filme.Sala);

                    // Associa a sala existente ao filme
                    filme.Sala = existingSala;
                }
                else
                {
                    // Se a sala não existe, você pode cadastrar ela antes de associar ao filme
                    _dbContext.Sala.Add(filme.Sala);
                }
            }

            _dbContext.Add(filme);
            await _dbContext.SaveChangesAsync();
            return Created("", filme);
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Filme filme)
        {
            if (_dbContext is null)
                return NotFound(ErrorResponse.DBisUnavailable);

            if (filme is null)
                return BadRequest(ErrorResponse.ObjectisNull);

            var existingFilme = await _dbContext.Filme
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(f => f.IdFilme == filme.IdFilme);

            if (existingFilme is null)
                return UnprocessableEntity(ErrorResponse.EntityNotFound);

            // Trate a associação da sala da mesma forma que no método de cadastro
            if (filme.Sala != null)
            {
                var existingSala = await _dbContext.Sala.FindAsync(filme.Sala.IdSala);

                if (existingSala != null)
                {
                    _dbContext.Entry(existingSala).CurrentValues.SetValues(filme.Sala);
                    filme.Sala = existingSala;
                }
                else
                {
                    _dbContext.Sala.Add(filme.Sala);
                }
            }

            if (filme.nomeFilme != "string" && filme.nomeFilme != null)
        {
            existingFilme.nomeFilme = filme.nomeFilme;
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

            // Atualize as propriedades do filme
            _dbContext.Entry(existingFilme).CurrentValues.SetValues(filme);

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