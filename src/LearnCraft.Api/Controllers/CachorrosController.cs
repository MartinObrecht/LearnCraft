﻿using LearnCraft.Domain;
using LearnCraft.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnCraft.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CachorrosController : ControllerBase
{
    private readonly CachorroDbContext _cachorroContext;

    public CachorrosController(CachorroDbContext cachorroContext)
    {
        _cachorroContext = cachorroContext;
    }

    [HttpGet]
    [Produces(contentType: "application/json")]
    [ProducesResponseType(typeof(IEnumerable<Cachorro>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetAsync()
    {
        var cachorros = await _cachorroContext.Cachorros.ToListAsync();

        if (cachorros.Count == 0)
        {
            return NoContent();
        }
        return Ok(cachorros);
    }

    [HttpGet("{id}")]
    [Produces(contentType: "application/json")]
    [ProducesResponseType(typeof(Cachorro), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var cachorro = await _cachorroContext.Cachorros.FindAsync(id);

        if (cachorro == null)
        {
            return NotFound();
        }
        return Ok(cachorro);
    }

    [HttpPost]
    [Produces(contentType: "application/json")]
    [ProducesResponseType(typeof(Cachorro), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync(Cachorro cachorro)
    {
        await _cachorroContext.Cachorros.AddAsync(cachorro);
        await _cachorroContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetByIdAsync), new { id = cachorro.Id }, cachorro);
    }

    [HttpDelete]
    [Produces(contentType: "application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var cachorro = await _cachorroContext.Cachorros.FindAsync(id);

        if (cachorro == null)
        {
            return NotFound();
        }

        _cachorroContext.Cachorros.Remove(cachorro);
        await _cachorroContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut]
    [Produces(contentType: "application/json")]
    [ProducesResponseType(typeof(Cachorro), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutAsync(int id, Cachorro cachorro)
    {
        if (id != cachorro.Id)
        {
            return BadRequest();
        }

        _cachorroContext.Entry(cachorro).State = EntityState.Modified;

        await _cachorroContext.SaveChangesAsync();

        return Ok(cachorro);
    }
}
