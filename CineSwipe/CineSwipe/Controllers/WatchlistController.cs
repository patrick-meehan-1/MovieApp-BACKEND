using Microsoft.AspNetCore.Mvc;

namespace CineSwipe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchlistController : ControllerBase
{
    [HttpGet]
    public IActionResult GetWatchlist()
    {
        return Ok("Watchlist endpoint ready");
    }
}
