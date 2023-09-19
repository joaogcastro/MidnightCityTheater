using Microsoft.AspNetCore.Mvc;
using WebApiFindWorks.Models;
using WebApiFindWorks.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApiFindWorks.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfissionalController : ControllerBase
{
    private WebApiFindWorksDbContext? _context;

    public ProfissionalController(WebApiFindWorksDbContext context)
    {
        _context = context;
    }

    [HttpGet]
[Route("listar")]
public async Task<ActionResult<IEnumerable<Profissional>>> Listar()
{
    if (_context is null)
    {
        return NotFound();
    }
    return await _context.Profissional.ToListAsync();
}

    [HttpGet()]
    [Route("buscar/{nome}")]
    public async Task<ActionResult<Profissional>> Buscar([FromRoute] string nome)
    {
        if(_context.Profissional is null)
            return NotFound();
        var profissional = await _context.Profissional.FindAsync(nome);
        if (profissional is null)
            return NotFound();
        return profissional;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Profissional profissional)
    {
        _context.Add(profissional);
        _context.SaveChanges();
        return Created("", profissional);
    }
}