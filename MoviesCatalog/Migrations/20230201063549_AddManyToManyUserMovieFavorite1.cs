using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyUserMovieFavorite1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_UserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    FavoritesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InFavoritesOfUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.FavoritesId, x.InFavoritesOfUsersId });
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Users_InFavoritesOfUsersId",
                        column: x => x.InFavoritesOfUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_InFavoritesOfUsersId",
                table: "MovieUser",
                column: "InFavoritesOfUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
