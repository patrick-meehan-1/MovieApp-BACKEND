using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineSwipe.Data;
using CineSwipe.Models;

namespace CineSwipe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchlistController : ControllerBase
{
    private readonly AppDbContext _context;

    public WatchlistController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/watchlist/user123
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetWatchlist(string userId)
    {
        var items = await _context.WatchlistItems
            .Where(w => w.UserId == userId)
            .ToListAsync();

        return Ok(items);
    }

    // POST: api/watchlist
    [HttpPost]
    public async Task<IActionResult> AddToWatchlist(WatchlistItem item)
    {
        // Validate movie exists
        var movieExists = await _context.Movies.AnyAsync(m => m.Id == item.MovieId);
        if (!movieExists)
            return NotFound($"Movie with ID {item.MovieId} does not exist.");

        // Prevent duplicates
        var alreadyExists = await _context.WatchlistItems
            .AnyAsync(w => w.MovieId == item.MovieId && w.UserId == item.UserId);

        if (alreadyExists)
            return Conflict("Movie already in watchlist.");

        _context.WatchlistItems.Add(item);
        await _context.SaveChangesAsync();

        return Ok(item);
    }

    // DELETE: api/watchlist/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromWatchlist(int id)
    {
        var item = await _context.WatchlistItems.FindAsync(id);
        if (item == null)
            return NotFound();

        _context.WatchlistItems.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
