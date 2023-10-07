using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;

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
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Bebida.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Bebida Bebida)
    {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(Bebida);
        await _dbContext.SaveChangesAsync();
        return Created("", Bebida);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Bebida>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            return NotFound();
        var bebida = await _dbContext.Bebida.FindAsync(id);
        if (bebida is null)
            return NotFound();
        return bebida;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Bebida bebida)
    {
        if (_dbContext is null)
            return NotFound();

        // Busque o registro existente pelo ID (ou outra chave primária) do usuário 
        var existingBebida = await _dbContext.Bebida.FindAsync(bebida.IdBebida);

        if (existingBebida is null)
            return NotFound();

        // Atualize apenas os campos que foram fornecidos no objeto usuário 
        if (bebida.Sabor != "string")
        {
            existingBebida.Sabor = bebida.Sabor;
        }

        if (bebida.Tamanho != "string")
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
        if (_dbContext is null) return NotFound();
        var bebida = await _dbContext.Bebida.FindAsync(id);
        if (bebida is null) return NotFound();
        _dbContext.Bebida.Remove(bebida);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}