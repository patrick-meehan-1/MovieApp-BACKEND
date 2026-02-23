using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineSwipe.Data;
using CineSwipe.Models;

namespace CineSwipe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/movies
    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
        var movies = await _context.Movies.ToListAsync();
        return Ok(movies);
    }

    // GET: api/movies/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    // GET: api/movies/genre/Action
    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetByGenre(string genre)
    {
        var movies = await _context.Movies
            .Where(m => m.Genre.ToLower() == genre.ToLower())
            .ToListAsync();
        return Ok(movies);
    }

    // POST: api/movies
    [HttpPost]
    public async Task<IActionResult> AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
    }

    // DELETE: api/movies/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}