using Microsoft.AspNetCore.Mvc;
using WebApiFindWorks.Models;
using WebApiFindWorks.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

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
    /*if (_dbContext is null) 
    {
        return NotFound();
    }*/
    return await _dbContext.Profissional.ToListAsync();
}

    [HttpGet()]
    [Route("buscar/{nome}")]
    public async Task<ActionResult<Profissional>> Buscar([FromRoute] string nome)
    {
        if(_dbContext.Profissional is null)
            return NotFound();
        var profissional = await _dbContext.Profissional.FindAsync(nome);
        if (profissional is null)
            return NotFound();
        return profissional;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async  Task<IActionResult> Cadastrar(Profissional profissional)
    {

        if(_dbContext.Profissional is null) return NotFound();
        _dbContext.AddAsync(profissional);
        await _dbContext.SaveChangesAsync();
        return Created("", profissional);
    }


    [HttpPut()]
    [Route("alterar")]

    public async Task<ActionResult> Alterar(Profissional profissional)
    {

        if(_dbContext.Profissional is null) return NotFound();
        if(await _dbContext.Profissional.FindAsync(profissional) is null)
            return NotFound();
        _dbContext.Update(profissional);
        await _dbContext.SaveChangesAsync();
        return Ok();

    }

    [HttpPatch()]
    [Route("mudardescricao/{nome}")]
    public async Task<ActionResult> MudarDescricao(string nome)
    {
        if(_dbContext.Profissional is null) return NotFound();
        var profissionalTemp = await _dbContext.Profissional.FindAsync(nome);
        if(profissionalTemp is null) return NotFound();
        profissionalTemp.Nome = nome;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
    [Route("excluir")]
    public async Task<ActionResult> Excluir(string nome)
    {
        if(_dbContext.Profissional is null) return NotFound();
        var profissional = await _dbContext.Profissional.FindAsync(nome);
        if(profissional is null) return NotFound();
        _dbContext.Profissional.Remove(profissional);
        await _dbContext.SaveChangesAsync();
        return Ok();

    }



}