using Microsoft.EntityFrameworkCore.Migrations;

namespace TJOHora_CA1MVC.Migrations
{
    public partial class seedGamesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "gameId", "developer", "genre", "name", "releaseDate" },
                values: new object[] { 1, "Respawn Entertainment", "Shooter", "Titanfall 2", "28/10/2016" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "gameId", "developer", "genre", "name", "releaseDate" },
                values: new object[] { 2, "Id Software", "Shooter", "Doom", "15/1/2016" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "gameId", "developer", "genre", "name", "releaseDate" },
                values: new object[] { 3, "From Software", "Shooter", "Dark Souls", "10/9/2009" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "gameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "gameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "gameId",
                keyValue: 3);
        }
    }
}
