using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Utils;
namespace WebApiFindWorks.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private APIDbContext _dbContext;

    public ClienteController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if (_dbContext is null)
        {
            return NotFound("Database unavailable");
        }
        return await _dbContext.Cliente.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Cliente cliente)
    {
        if (_dbContext is null) return NotFound("Database unavailable");
        if (cliente.CPF == null || cliente.CPF == "string") return BadRequest("CPF is null");
        if (CPFUtils.IsCpfValid(cliente.CPF) == false)
        {
            var errorObject = new
            {
                Message = "CPF inválido. Por favor, insira um CPF válido.",
                ErrorCode = "INVALID_CPF"
            };
            return UnprocessableEntity(errorObject);
        }
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
            return UnprocessableEntity("No entities were found with this ID");
        return cliente;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        if (_dbContext is null)
            return NotFound("Database unavailable");

        // Busque o registro existente pelo ID (ou outra chave primária) do usuário
        var existingCliente = await _dbContext.Cliente.FindAsync(cliente.IdCliente);

        if (existingCliente is null)
            return UnprocessableEntity("No entities were found with this ID");

        // Atualize apenas os campos que foram fornecidos no objeto usuário
        if (cliente.Nome != "string")
        {
            existingCliente.Nome = cliente.Nome;
        }

        if (cliente.CPF != "string")
        {
            existingCliente.CPF = cliente.CPF;
        }

        if (cliente.Telefone != "string")
        {
            existingCliente.Telefone = cliente.Telefone;
        }

        if (cliente.Email != "string")
        {
            existingCliente.Email = cliente.Email;
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
        if (_dbContext is null) return NotFound("Database unavailable");
        var cliente = await _dbContext.Cliente.FindAsync(id);
        if (cliente is null) return UnprocessableEntity("No entities were found with this ID");
        _dbContext.Cliente.Remove(cliente);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}