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
        if (_dbContext is null)
            return NotFound(ErrorResponse.DBisUnavailable);

        var vendas = await _dbContext.Venda
            .Include(v => v.Snack)
                .ThenInclude(s => s.Pipocas)
            .Include(v => v.Snack)
                .ThenInclude(s => s.Bebidas)
            .Include(v => v.Snack)
                .ThenInclude(s => s.Doces)
            .Include(v => v.Cliente)
            .Include(v => v.Ingresso)
                .ThenInclude(i => i.Filme)
                .ThenInclude(f => f.Sala)
            .ToListAsync();
            

        return vendas;
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
    [Route("buscar/{cpf}")]
    public async Task<ActionResult<IEnumerable<Venda>>> Buscar([FromRoute] string cpf)
    {
        if (_dbContext is null)
            return NotFound(ErrorResponse.DBisUnavailable);

        // Incluindo a propriedade Cliente na consulta
        var vendas = await _dbContext.Venda
            .Include(v => v.Cliente)
            //.Where(v => v.Cliente.CPF == cpf)
            .Include(v => v.Snack)
                    .ThenInclude(s => s.Pipocas)
            .Include(v => v.Snack)
                .ThenInclude(s => s.Bebidas)
            .Include(v => v.Snack)
                .ThenInclude(s => s.Doces)
            .Include(v => v.Cliente)
            .ToListAsync();

        if (vendas.Count == 0)
            return UnprocessableEntity(ErrorResponse.EntityNotFound);

        return vendas;
    }

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