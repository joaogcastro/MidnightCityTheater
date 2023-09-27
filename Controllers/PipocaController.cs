using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;

namespace MidnightCityTheater.Controllers;

[ApiController]
[Route("[controller]")]
public class PipocaController : ControllerBase
{
    private APIDbContext _dbContext;

    public PipocaController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pipoca>>> Listar()
    {
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Pipoca.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Pipoca Pipoca)
    {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(Pipoca);
        await _dbContext.SaveChangesAsync();
        return Created("", Pipoca);
    }
}