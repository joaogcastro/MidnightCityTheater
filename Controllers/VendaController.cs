using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;
using MidnightCityTheater.Utils;

namespace MidnightCityTheater.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
    private APIDbContext _dbContext;

    public VendaController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Venda>>> Listar()
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        return await _dbContext.Venda.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Venda venda)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        _dbContext.Add(venda);
        await _dbContext.SaveChangesAsync();
        return Created("", venda);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Venda>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var venda = await _dbContext.Venda.FindAsync(id);
        if (venda is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        return venda;
    }

    /*
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Bebida bebida)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (bebida is null) return BadRequest(ErrorResponse.ObjectisNull);
        var existingbebida = await _dbContext.Bebida.FindAsync(bebida.IdBebida);
        if (existingbebida is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);

        // Atualize apenas os campos que foram fornecidos no objeto
        

        // Marque o registro como modificado no contexto do EF 
        _dbContext.Entry(existingbebida).State = EntityState.Modified;

        // Salve as alterações no banco de dados 
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
    */

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var venda = await _dbContext.Venda.FindAsync(id);
        if (venda is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        _dbContext.Venda.Remove(venda);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}