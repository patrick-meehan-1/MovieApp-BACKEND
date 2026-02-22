using Microsoft.EntityFrameworkCore;
using CineSwipe.Models;
using System.Collections.Generic;

namespace CineSwipe.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<WatchlistItem> WatchlistItems { get; set; }
}
