using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;
using MidnightCityTheater.Utils;

namespace MidnightCityTheater.Controllers;

[ApiController]
[Route("[controller]")]
public class DoceController : ControllerBase
{
    private APIDbContext _dbContext;

    public DoceController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Doce>>> Listar()
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        return await _dbContext.Doce.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Doce doce)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (doce.Nome is null || doce.Preco == 0) return BadRequest(ErrorResponse.AttributeisNull);
        _dbContext.Add(doce); 
        await _dbContext.SaveChangesAsync();
        return Created("", doce);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Doce>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var doce = await _dbContext.Doce.FindAsync(id);
        if (doce is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        return doce;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Doce doce)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (doce is null) return BadRequest(ErrorResponse.ObjectisNull);
        // Busque o registro existente pelo ID
        var existingDoce = await _dbContext.Doce.FindAsync(doce.IdDoce);
        if (existingDoce is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);

        // Atualize apenas os campos que foram fornecidos no objeto
        if (doce.Nome != "string" && doce != null)
        {
            existingDoce.Nome = doce.Nome;
        }

        if (doce!.Preco != 0)
        {
            existingDoce.Preco = doce.Preco;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingDoce).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var doce = await _dbContext.Doce.FindAsync(id);
        if (doce is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        _dbContext.Doce.Remove(doce);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}