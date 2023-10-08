using Microsoft.AspNetCore.Mvc;
using MidnightCityTheater.Models;
using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Utils;
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

            if (_dbContext is null)
            {
            return NotFound("Database unavailable");
            }

            var funcList = await _dbContext.Funcionario.ToListAsync();
            return Ok(funcList);
        }  

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Funcionario funcionario)
    {
        if (_dbContext is null) return NotFound("Database unavailable");
        if (funcionario.CPFfunc == null || funcionario.CPFfunc == "string") return BadRequest("CPF is null");
        if (CPFUtils.IsCpfValid(funcionario.CPFfunc) == false)
        {
            var errorObject = new
            {
                Message = "CPF inválido. Por favor, insira um CPF válido.",
                ErrorCode = "INVALID_CPF"
            };
            return UnprocessableEntity(errorObject);
        }
        _dbContext.Add(funcionario);
        await _dbContext.SaveChangesAsync();
        return Created("", funcionario);
    }

    [HttpGet()]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Funcionario>> Buscar([FromRoute] int id)
    {
        if (_dbContext is null)
            if (_dbContext is null) return NotFound("Database unavailable");
        var employee = await _dbContext.Funcionario.FindAsync(id);
        if (employee is null)
            return UnprocessableEntity("No entities were found with this ID");
        return employee;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        if (_dbContext is null)
            return NotFound("Database unavailable");

        // Busque o registro existente pelo ID (ou outra chave primária) do usuário
        var existingFuncionario = await _dbContext.Funcionario.FindAsync(funcionario.IdFuncionario);

        if (existingFuncionario is null)
            return UnprocessableEntity("No entities were found with this ID");

        // Atualize apenas os campos que foram fornecidos no objeto usuário
        if (funcionario.NomeFunc != "string")
        {
            existingFuncionario.NomeFunc = funcionario.NomeFunc;
        }

        if (funcionario.CPFfunc != "string")
        {
            existingFuncionario.CPFfunc = funcionario.CPFfunc;
        }

        if (funcionario.TelefoneFunc != "string")
        {
            existingFuncionario.TelefoneFunc = funcionario.TelefoneFunc;
        }

        if (funcionario.EmailFunc != "string")
        {
            existingFuncionario.EmailFunc = funcionario.EmailFunc;
        }

        // Marque o registro como modificado no contexto do EF
        _dbContext.Entry(existingFuncionario).State = EntityState.Modified;

        // Salve as alterações no banco de dados
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir([FromRoute] int id)
    {
        if (_dbContext is null) return NotFound("Database unavailable");
        var funcdel = await _dbContext.Funcionario.FindAsync(id);
        if (funcdel is null) return UnprocessableEntity("No entities were found with this ID");
        _dbContext.Funcionario.Remove(funcdel);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
 
}

}