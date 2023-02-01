using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesCatalog.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserMovieToFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MovieUser",
                schema: "dbo",
                newName: "Favorites",
                newSchema: "dbo"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Favorites",
                schema: "dbo",
                newName: "MovieUser",
                newSchema: "dbo"
                );
        }
    }
}
