using LearnCraft.Domain;
using LearnCraft.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnCraft.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CachorrosController : ControllerBase
{
    private readonly CachorroContext _cachorroContext;

    public CachorrosController(CachorroContext cachorroContext)
    {
        _cachorroContext = cachorroContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cachorros = await _cachorroContext.Cachorros.ToListAsync();

        if (cachorros.Count == 0)
        {
            return NoContent();
        }
        return Ok(cachorros);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cachorro = await _cachorroContext.Cachorros.FindAsync(id);

        if (cachorro == null)
        {
            return NotFound();
        }
        return Ok(cachorro);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Cachorro cachorro)
    {
        await _cachorroContext.Cachorros.AddAsync(cachorro);
        await _cachorroContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = cachorro.Id }, cachorro);
    }
}
