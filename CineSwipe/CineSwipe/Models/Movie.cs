namespace CineSwipe.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public double Rating { get; set; }
}

