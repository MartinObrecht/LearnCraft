using Microsoft.AspNetCore.Mvc;

namespace LearnCraft.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CachorrosController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Cachorros");
    }
}
