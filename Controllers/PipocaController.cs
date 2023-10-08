using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;
using MidnightCityTheater.Utils;

namespace MidnightCityTheater.Controllers;

[ApiController]
[Route("[controller]")]
public class PipocaController : ControllerBase
{
    private APIDbContext _dbContext;

    public PipocaController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pipoca>>> Listar()
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        return await _dbContext.Pipoca.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Pipoca pipoca)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (pipoca.Sabor == null || pipoca.Tamanho == null || pipoca.Preco == 0) return BadRequest(ErrorResponse.AttributeisNull);
        _dbContext.Add(pipoca);
        await _dbContext.SaveChangesAsync();
        return Created("", pipoca);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Pipoca>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var pipoca = await _dbContext.Pipoca.FindAsync(id);
        if (pipoca is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        return pipoca;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pipoca pipoca)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (pipoca is null) return BadRequest(ErrorResponse.ObjectisNull);
        // Busque o registro existente pelo ID
        var existingPipoca = await _dbContext.Pipoca.FindAsync(pipoca.IdPipoca);
        if (existingPipoca is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);

        // Atualize apenas os campos que foram fornecidos no objeto
        if (pipoca.Sabor != "string" && pipoca != null)
        {
            existingPipoca.Sabor = pipoca.Sabor;
        }

        if (pipoca!.Tamanho != "string" && pipoca != null)
        {
            existingPipoca.Tamanho = pipoca.Tamanho;
        }

        if (pipoca!.Preco != 0)
        {
            existingPipoca.Preco = pipoca.Preco;
        }

        // Marque o registro como modificado no contexto do EF 
        _dbContext.Entry(existingPipoca).State = EntityState.Modified;

        // Salve as alterações no banco de dados 
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var pipoca = await _dbContext.Pipoca.FindAsync(id);
        if (pipoca is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        _dbContext.Pipoca.Remove(pipoca);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}