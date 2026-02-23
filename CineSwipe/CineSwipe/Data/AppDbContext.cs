using Microsoft.EntityFrameworkCore;
using CineSwipe.Models;

namespace CineSwipe.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<WatchlistItem> WatchlistItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "The Shawshank Redemption", Genre = "Drama", PosterUrl = "https://posters.movieposterdb.com/11_08/1994/111161/s_111161_e9ccda65.jpg", Rating = 9.3 },
            new Movie { Id = 2, Title = "The Godfather", Genre = "Crime", PosterUrl = "https://posters.movieposterdb.com/22_12/1991/809433/s_the-godfather-movie-poster_d53af75d.jpg", Rating = 9.2 },
            new Movie { Id = 3, Title = "The Dark Knight", Genre = "Action", PosterUrl = "https://posters.movieposterdb.com/12_06/2011/2258647/l_2258647_c0830db9.jpg", Rating = 9.0 },
            new Movie { Id = 4, Title = "Pulp Fiction", Genre = "Crime", PosterUrl = "https://posters.movieposterdb.com/25_11/1994/110912/s_pulp-fiction-movie-poster_f099050c.jpg", Rating = 8.9 },
            new Movie { Id = 5, Title = "Forrest Gump", Genre = "Drama", PosterUrl = "https://posters.movieposterdb.com/12_04/1994/109830/s_109830_58524cd6.jpg", Rating = 8.8 },
            new Movie { Id = 6, Title = "Inception", Genre = "Sci-Fi", PosterUrl = "https://posters.movieposterdb.com/10_06/2010/1375666/l_1375666_07030c72.jpg", Rating = 8.8 },
            new Movie { Id = 7, Title = "The Matrix", Genre = "Sci-Fi", PosterUrl = "https://posters.movieposterdb.com/06_01/1999/0133093/s_77607_0133093_ab8bc972.jpg", Rating = 8.7 },
            new Movie { Id = 8, Title = "Goodfellas", Genre = "Crime", PosterUrl = "https://posters.movieposterdb.com/05_09/1990/0099685/s_54529_0099685_307a5bd2.jpg", Rating = 8.7 },
            new Movie { Id = 9, Title = "Interstellar", Genre = "Sci-Fi", PosterUrl = "https://posters.movieposterdb.com/14_09/2014/816692/s_816692_593eaeff.jpg", Rating = 8.6 },
            new Movie { Id = 10, Title = "The Silence of the Lambs", Genre = "Thriller", PosterUrl = "https://posters.movieposterdb.com/21_02/1991/102926/s_102926_90bd926b.jpg", Rating = 8.6 }
        );
    }
}