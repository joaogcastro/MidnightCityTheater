using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;
using MidnightCityTheater.Utils;

namespace MidnightCityTheater.Controllers;

[ApiController]
[Route("[controller]")]
public class BebidaController : ControllerBase
{
    private APIDbContext _dbContext;

    public BebidaController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Bebida>>> Listar()
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        return await _dbContext.Bebida.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Bebida bebida)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (bebida.Sabor == null || bebida.Tamanho == null || bebida.Preco == 0) return BadRequest(ErrorResponse.AttributeisNull);
        _dbContext.Add(bebida);
        await _dbContext.SaveChangesAsync();
        return Created("", bebida);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Bebida>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var bebida = await _dbContext.Bebida.FindAsync(id);
        if (bebida is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        return bebida;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Bebida bebida)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (bebida is null) return BadRequest(ErrorResponse.ObjectisNull);
        var existingBebida = await _dbContext.Bebida.FindAsync(bebida.IdBebida);
        if (existingBebida is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);

        // Atualize apenas os campos que foram fornecidos no objeto
        if (bebida.Sabor != "string" && bebida.Sabor != null)
        {
            existingBebida.Sabor = bebida.Sabor;
        }

        if (bebida.Tamanho != "string" && bebida.Tamanho != null)
        {
            existingBebida.Tamanho = bebida.Tamanho;
        }

        if (bebida.Preco != 0)
        {
            existingBebida.Preco = bebida.Preco;
        }

        // Marque o registro como modificado no contexto do EF 
        _dbContext.Entry(existingBebida).State = EntityState.Modified;

        // Salve as alterações no banco de dados 
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var bebida = await _dbContext.Bebida.FindAsync(id);
        if (bebida is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        _dbContext.Bebida.Remove(bebida);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}