using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AdjustFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Movie",
                table: "Favorites",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Favorites",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_MovieId",
                table: "Favorites",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Movies_MovieId",
                table: "Favorites",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Movies_MovieId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_MovieId",
                table: "Favorites");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Favorites",
                newName: "Movie");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Favorites",
                newName: "User");
        }
    }
}
