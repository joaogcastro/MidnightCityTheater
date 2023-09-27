using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
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
            return NotFound();
        }
        return await _dbContext.Cliente.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Cliente cliente)
    {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(cliente);
        await _dbContext.SaveChangesAsync();
        return Created("", cliente);
    }
    /*
    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Usuario>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            return NotFound();
        var usuario = await _dbContext.Usuario.FindAsync(id);
        if (usuario is null)
            return NotFound();
        return usuario;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Usuario usuario)
    {
        if (_dbContext is null)
            return NotFound();

        // Busque o registro existente pelo ID (ou outra chave primária) do usuário
        var existingUsuario = await _dbContext.Usuario.FindAsync(usuario.Id);

        if (existingUsuario is null)
            return NotFound();

        // Atualize apenas os campos que foram fornecidos no objeto usuário
        if (usuario.NomeUsuario != "string")
        {
            existingUsuario.NomeUsuario = usuario.NomeUsuario;
        }

        if (usuario.Senha != "string")
        {
            existingUsuario.Senha = usuario.Senha;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingUsuario).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound();
        var usuario = await _dbContext.Usuario.FindAsync(id);
        if (usuario is null) return NotFound();
        _dbContext.Usuario.Remove(usuario);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }*/
}
