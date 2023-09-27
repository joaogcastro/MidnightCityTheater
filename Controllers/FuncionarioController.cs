using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApiFindWorks.Controllers{

[ApiController]
[Route("[controller]")]

public class FuncionarioController : ControllerBase
{

    private APIDbContext _dbContext;

    public FuncionarioController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
        {
            var funcList = await _dbContext.Funcionario.ToListAsync();
            return Ok(funcList);
        }  

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Funcionario funcionario)
    {
        if(_dbContext is null) return NotFound();
        _dbContext.Add(funcionario);
        await _dbContext.SaveChangesAsync();
        return Created("", funcionario);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Funcionario>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            return NotFound();
        var employee = await _dbContext.Funcionario.FindAsync(id);
        if (employee is null)
            return NotFound();
        return employee;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        if (_dbContext is null)
            return NotFound();
        var existingFunc = await _dbContext.Funcionario.FindAsync(funcionario.IdFuncionario);

        if (existingFunc is null)
            return NotFound();

        if (!string.IsNullOrEmpty(funcionario.NomeFunc))
        {
            existingFunc.NomeFunc = funcionario.NomeFunc;
        }

        if (!string.IsNullOrEmpty(funcionario.CPFfunc))
        {
            existingFunc.CPFfunc = funcionario.CPFfunc;
        }

        if (!string.IsNullOrEmpty(funcionario.EmailFunc))
        {
            existingFunc.EmailFunc = funcionario.EmailFunc;
        }

        if (!string.IsNullOrEmpty(funcionario.TelefoneFunc))
        {
            existingFunc.TelefoneFunc = funcionario.TelefoneFunc;
        }

        _dbContext.Entry(existingFunc).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound();
        var funcdel = await _dbContext.Funcionario.FindAsync(id);
        if (funcdel is null) return NotFound();
        _dbContext.Funcionario.Remove(funcdel);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
 
}

}