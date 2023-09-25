using Microsoft.AspNetCore.Mvc;
using WebApiFindWorks.Models;
using WebApiFindWorks.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApiFindWorks.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfissionalController : ControllerBase
{
    private WebApiFindWorksDbContext? _dbContext;

    public ProfissionalController(WebApiFindWorksDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Profissional>>> Listar()
    {
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Profissional.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Profissional>> Buscar([FromRoute] int id)
    {
        if (_dbContext.Profissional is null)
            return NotFound();
        var profissional = await _dbContext.Profissional.FindAsync(id);
        if (profissional is null)
            return NotFound();
        return profissional;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Profissional profissional)
    {

        if (_dbContext.Profissional is null) return NotFound();
        _dbContext.AddAsync(profissional);
        await _dbContext.SaveChangesAsync();
        return Created("", profissional);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Profissional profissional)
    {
        if (_dbContext.Profissional is null)
            return NotFound();

        // Busque o registro existente pelo ID (ou outra chave primária) do profissional
        var existingProfissional = await _dbContext.Profissional.FindAsync(profissional.Id);

        if (existingProfissional is null)
            return NotFound();

        // Substitua a verificação por "Profissao.(Atributo) = 'string'"
        if (profissional.Profissao == "string")
        {
            existingProfissional.Profissao = profissional.Profissao;
        }

        if (profissional.Nome != "string")
        {
            existingProfissional.Nome = profissional.Nome;
        }

        if (profissional.Email != "string")
        {
            existingProfissional.Email = profissional.Email;
        }

        if (profissional.Telefone != "string")
        {
            existingProfissional.Telefone = profissional.Telefone;
        }

        if (profissional.Cidade != "string")
        {
            existingProfissional.Cidade = profissional.Cidade;
        }

        if (profissional.Bairro != "string")
        {
            existingProfissional.Bairro = profissional.Bairro;
        }

        if (profissional.ValorHora != 0.0)
        {
            existingProfissional.ValorHora = profissional.ValorHora;
        }

        if (profissional.DistanciaDoCentro != 0.0)
        {
            existingProfissional.DistanciaDoCentro = profissional.DistanciaDoCentro;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingProfissional).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPatch()]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_dbContext.Profissional is null) return NotFound();
        var profissional = await _dbContext.Profissional.FindAsync(id);
        if (profissional is null) return NotFound();
        _dbContext.Profissional.Remove(profissional);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}