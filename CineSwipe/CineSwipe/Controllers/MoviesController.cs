using Microsoft.AspNetCore.Mvc;

namespace CineSwipe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok("Movies endpoint ready");
    }
}
