using Microsoft.EntityFrameworkCore.Migrations;

namespace TJOHora_CA1MVC.Migrations
{
    public partial class AddedGamePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Games",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameId = table.Column<int>(nullable: true),
                    NoOfItems = table.Column<int>(nullable: false),
                    CartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Games_gameId",
                        column: x => x.gameId,
                        principalTable: "Games",
                        principalColumn: "gameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "gameId",
                keyValue: 1,
                column: "Price",
                value: 30.50m);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "gameId",
                keyValue: 2,
                column: "Price",
                value: 50.50m);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "gameId",
                keyValue: 3,
                columns: new[] { "Price", "genre" },
                values: new object[] { 10.99m, "Rpg" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_gameId",
                table: "CartItems",
                column: "gameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "gameId",
                keyValue: 3,
                column: "genre",
                value: "Shooter");
        }
    }
}
