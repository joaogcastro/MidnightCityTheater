using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidnightCityTheater.Data;
using MidnightCityTheater.Models;

namespace MidnightCityTheater.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
    private APIDbContext _dbContext;

    public VendaController(APIDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Venda>>> Listar()
    {
        if (_dbContext is null)
        {
            return NotFound();
        }
        return await _dbContext.Venda.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Venda venda)
    {
        if (_dbContext is null) return NotFound();
        _dbContext.Add(venda);
        await _dbContext.SaveChangesAsync();
        return Created("", venda);
    }
}