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
}