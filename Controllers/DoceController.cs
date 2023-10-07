using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;

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
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Doce.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Doce doce)
    {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(doce); 
        await _dbContext.SaveChangesAsync();
        return Created("", doce);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Doce>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            return NotFound();
        var doce = await _dbContext.Doce.FindAsync(id);
        if (doce is null)
            return NotFound();
        return doce;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Doce doce)
    {
        if (_dbContext is null)
            return NotFound();

        // Busque o registro existente pelo ID (ou outra chave primária) do usuário
        var existingDoce = await _dbContext.Doce.FindAsync(doce.IdDoce);

        if (existingDoce is null)
            return NotFound();

        // Atualize apenas os campos que foram fornecidos no objeto usuário
        if (doce.Nome != "string")
        {
            existingDoce.Nome = doce.Nome;
        }

        if (doce.Preco != 0)
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
        if (_dbContext is null) return NotFound();
        var Doce = await _dbContext.Doce.FindAsync(id);
        if (Doce is null) return NotFound();
        _dbContext.Doce.Remove(Doce);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}