using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedreiragemBR.Data;
namespace PedreiragemBR.Controllers;
[ApiController]
[Route("[controller]")]
public class CarroController : ControllerBase
{

    private EstacionamentoDbContext _context;
    public CarroController(EstacionamentoDbContext context)
    {
        _context = context;
    }

    [httpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Carro>>> Listar(){
        if(_context.Carro is null)        {
            return NotFound();
        }
        return await _context.Carro.ToListAsync();
    }

   

    

}