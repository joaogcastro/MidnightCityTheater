using Microsoft.AspNetCore.Mvc;
using WebApiFindWorks.Models;
using API_Estacionamento.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Estacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class CarroController : ControllerBase
{
    private EstacionamentoDbContext? _context;

    public CarroController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Carro>>> Listar()
    {
        if(_context.Carro is null)
            return NotFound();
        return await _context.Carro.ToListAsync();
    }
    [HttpGet()]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Carro>> Buscar([FromRoute] string placa)
    {
        if(_context.Carro is null)
            return NotFound();
        var carro = await _context.Carro.FindAsync(placa);
        if (carro is null)
            return NotFound();
        return carro;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Carro carro)
    {
        _context.Add(carro);
        _context.SaveChanges();
        return Created("", carro);
    }
}





