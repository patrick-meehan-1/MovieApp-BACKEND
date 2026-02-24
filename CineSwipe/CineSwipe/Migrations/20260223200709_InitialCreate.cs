using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CineSwipe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    PosterUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchlistItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "PosterUrl", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "Drama", "https://posters.movieposterdb.com/11_08/1994/111161/s_111161_e9ccda65.jpg", 9.3000000000000007, "The Shawshank Redemption" },
                    { 2, "Crime", "https://posters.movieposterdb.com/22_12/1991/809433/s_the-godfather-movie-poster_d53af75d.jpg", 9.1999999999999993, "The Godfather" },
                    { 3, "Action", "https://posters.movieposterdb.com/12_06/2011/2258647/l_2258647_c0830db9.jpg", 9.0, "The Dark Knight" },
                    { 4, "Crime", "https://posters.movieposterdb.com/25_11/1994/110912/s_pulp-fiction-movie-poster_f099050c.jpg", 8.9000000000000004, "Pulp Fiction" },
                    { 5, "Drama", "https://posters.movieposterdb.com/12_04/1994/109830/s_109830_58524cd6.jpg", 8.8000000000000007, "Forrest Gump" },
                    { 6, "Sci-Fi", "https://posters.movieposterdb.com/10_06/2010/1375666/l_1375666_07030c72.jpg", 8.8000000000000007, "Inception" },
                    { 7, "Sci-Fi", "https://posters.movieposterdb.com/06_01/1999/0133093/s_77607_0133093_ab8bc972.jpg", 8.6999999999999993, "The Matrix" },
                    { 8, "Crime", "https://posters.movieposterdb.com/05_09/1990/0099685/s_54529_0099685_307a5bd2.jpg", 8.6999999999999993, "Goodfellas" },
                    { 9, "Sci-Fi", "https://posters.movieposterdb.com/14_09/2014/816692/s_816692_593eaeff.jpg", 8.5999999999999996, "Interstellar" },
                    { 10, "Thriller", "https://posters.movieposterdb.com/21_02/1991/102926/s_102926_90bd926b.jpg", 8.5999999999999996, "The Silence of the Lambs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "WatchlistItems");
        }
    }
}
