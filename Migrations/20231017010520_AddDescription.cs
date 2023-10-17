using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafe.Migrations
{
    public partial class AddDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Favorite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Favorite",
                keyColumn: "FavoritesId",
                keyValue: 1,
                column: "Description",
                value: "A dark, robust blend.");

            migrationBuilder.UpdateData(
                table: "Favorite",
                keyColumn: "FavoritesId",
                keyValue: 2,
                column: "Description",
                value: "A light, decaf blend.");

            migrationBuilder.UpdateData(
                table: "Favorite",
                keyColumn: "FavoritesId",
                keyValue: 3,
                column: "Description",
                value: "Traditional hot chocolate, with whip!");

            migrationBuilder.UpdateData(
                table: "Favorite",
                keyColumn: "FavoritesId",
                keyValue: 4,
                column: "Description",
                value: "A tasty latte made with caramel and vanilla.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Favorite");
        }
    }
}
