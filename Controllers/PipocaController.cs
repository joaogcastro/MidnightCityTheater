using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;

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
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Pipoca.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Pipoca pipoca)
    {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(pipoca);
        await _dbContext.SaveChangesAsync();
        return Created("", pipoca);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Pipoca>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            return NotFound();
        var pipoca = await _dbContext.Pipoca.FindAsync(id);
        if (pipoca is null)
            return NotFound();
        return pipoca;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pipoca pipoca)
    {
        if (_dbContext is null)
            return NotFound();

        // Busque o registro existente pelo ID (ou outra chave primária) do usuário 
        var existingPipoca = await _dbContext.Pipoca.FindAsync(pipoca.IdPipoca);

        if (existingPipoca is null)
            return NotFound();

        // Atualize apenas os campos que foram fornecidos no objeto usuário 
        if (pipoca.Sabor != "string")
        {
            existingPipoca.Sabor = pipoca.Sabor;
        }

        if (pipoca.Tamanho != "string")
        {
            existingPipoca.Tamanho = pipoca.Tamanho;
        }

        if (pipoca.Preco != 0)
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
        if (_dbContext is null) return NotFound();
        var pipoca = await _dbContext.Pipoca.FindAsync(id);
        if (pipoca is null) return NotFound();
        _dbContext.Pipoca.Remove(pipoca);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}