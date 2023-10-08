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
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        return await _dbContext.Cliente.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Cliente cliente)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (cliente.Nome == null || cliente.Nome == "string") return BadRequest(ErrorResponse.AttributeisNull);
        if (cliente.CPF == null || cliente.CPF == "string") return BadRequest(ErrorResponse.CPFisNull);
        if (CPFUtils.IsCpfValid(cliente.CPF) == false) return UnprocessableEntity(ErrorResponse.CPFisInvalid);
        cliente.CPF = CPFUtils.FormatCPF(cliente.CPF);
        if(cliente.Email != null && cliente.Email != "string")
        {
            if(EmailUtils.IsValidEmail(cliente.Email!)==false) return UnprocessableEntity(ErrorResponse.EmailisInvalid);
        }
        if(cliente.Telefone !=null && cliente.Telefone != "string")
        {
            cliente.Telefone = TelefoneUtils.FormatPhoneNumber(cliente.Telefone!);
            if(TelefoneUtils.IsValidPhoneNumber(cliente.Telefone) == false) return UnprocessableEntity(ErrorResponse.PhoneisInvalid);
        }
        _dbContext.Add(cliente);
        await _dbContext.SaveChangesAsync();
        return Created("", cliente);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Cliente>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var cliente = await _dbContext.Cliente.FindAsync(id);
        if (cliente is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        return cliente;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        if (cliente is null) return BadRequest(ErrorResponse.ObjectisNull);
        // Busque o registro existente pelo ID
        var existingCliente = await _dbContext.Cliente.FindAsync(cliente.IdCliente);
        if (existingCliente is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);

        // Atualize apenas os campos que foram fornecidos no objeto
        if (cliente.Nome != "string" && cliente.Nome != null)
        {
            existingCliente.Nome = cliente.Nome;
        }

        if (cliente.CPF != "string" && cliente.CPF != null)
        {
            cliente.CPF = CPFUtils.FormatCPF(cliente.CPF!);
            if (CPFUtils.IsCpfValid(cliente.CPF) == false) return UnprocessableEntity(ErrorResponse.CPFisInvalid);
            existingCliente.CPF = cliente.CPF;
        }

        if (cliente.Telefone != "string" && cliente.Telefone != null)
        {
            cliente.Telefone = TelefoneUtils.FormatPhoneNumber(cliente.Telefone!);
            if(TelefoneUtils.IsValidPhoneNumber(cliente.Telefone) == false) return UnprocessableEntity(ErrorResponse.PhoneisInvalid);
            existingCliente.Telefone = cliente.Telefone;
        }

        if (cliente.Email != "string" && cliente.Email != null)
        {
            if(EmailUtils.IsValidEmail(cliente.Email!)==false) return UnprocessableEntity(ErrorResponse.EmailisInvalid);
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
        if (_dbContext is null) return NotFound(ErrorResponse.DBisUnavailable);
        var cliente = await _dbContext.Cliente.FindAsync(id);
        if (cliente is null) return UnprocessableEntity(ErrorResponse.EntityNotFound);
        _dbContext.Cliente.Remove(cliente);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}