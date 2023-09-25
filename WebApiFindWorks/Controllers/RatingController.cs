using Microsoft.AspNetCore.Mvc;
using WebApiFindWorks.Models;
using WebApiFindWorks.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApiFindWorks.Controllers;

[ApiController]
[Route("[controller]")]
public class RatingController : ControllerBase
{
    private WebApiFindWorksDbContext? _dbContext;

    public RatingController(WebApiFindWorksDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet()]
    [Route("mediaRating/{idProfissional}")]
    public async Task<ActionResult<double>> CalcularMediaRating([FromRoute] int idProfissional)
    {
        if (_dbContext.Profissional is null) return NotFound();

        var profissional = await _dbContext.Profissional.Include(p => p.Ratings).FirstOrDefaultAsync(p => p.Id == idProfissional);

        if (profissional is null) return NotFound();

        if (profissional.Ratings == null || profissional.Ratings.Count == 0)
            return Ok(0.0); // Se o Profissional não tiver Ratings, a média é 0.0

        // Calcule a média dos Ratings
        double mediaRating = profissional.Ratings.Average(r => r.Value);

        return Ok(mediaRating);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Rating>>> Listar()
    {
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Rating.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Rating>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound();
        var rating = await _dbContext.Rating.FindAsync(id);
        if (rating is null) return NotFound();
        return rating;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Rating rating)
    {
        if (_dbContext is null) return NotFound();

        // Busque o Profissional pelo idProfissional fornecido
        var profissional = await _dbContext.Profissional.FindAsync(rating.ProfissionalId);

        if (profissional is null)
        {
            // Se o Profissional não existir, retorne NotFound ou outra resposta apropriada
            return NotFound();
        }

        _dbContext.Add(rating);
        await _dbContext.SaveChangesAsync();
        return Created("", rating);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Rating rating)
    {
        if (_dbContext is null) return NotFound();

        // Busque o registro existente pelo ID (ou outra chave primária) do Rating
        var existingRating = await _dbContext.Rating.FindAsync(rating.Id);

        if (existingRating is null) return NotFound();

        // Atualize apenas os campos que foram fornecidos no objeto Rating
        existingRating.Value = rating.Value;

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingRating).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound();
        var rating = await _dbContext.Rating.FindAsync(id);
        if (rating is null) return NotFound();
        _dbContext.Rating.Remove(rating);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}