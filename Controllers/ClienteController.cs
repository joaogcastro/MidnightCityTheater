using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApiFindWorks.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController: ControllerBase
{
    private APIDbContext _dbContext;

    public ClienteController(APIDbContext context) {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task < ActionResult < IEnumerable < Cliente>>> Listar() {
        if (_dbContext is null) {
            return NotFound();
        }
        return await _dbContext.Cliente.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task < IActionResult > Cadastrar(Cliente cliente) {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(cliente);
        await _dbContext.SaveChangesAsync();
        return Created("", cliente);
    }
    
    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Cliente>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            return NotFound();
        var cliente = await _dbContext.Cliente.FindAsync(id);
        if (cliente is null)
            return NotFound();
        return cliente;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        if (_dbContext is null)
            return NotFound();

        // Busque o registro existente pelo ID (ou outra chave primária) do usuário
        var existingCliente = await _dbContext.Cliente.FindAsync(cliente.Id);

        if (existingCliente is null)
            return NotFound();

        // Atualize apenas os campos que foram fornecidos no objeto usuário
        if (cliente.NomeCliente != "string")
        {
            existingCliente.NomeCliente = cliente.NomeCliente;
        }

        if (cliente.Senha != "string")
        {
            existingCliente.Senha = cliente.Senha;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingCliente).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound();
        var cliente = await _dbContext.Cliente.FindAsync(id);
        if (cliente is null) return NotFound();
        _dbContext.Cliente.Remove(cliente);
        await _dbContext.SaveChangesAsync();
        return Ok();
}