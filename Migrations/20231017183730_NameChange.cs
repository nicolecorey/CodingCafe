using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafe.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Favorite",
                table: "Favorite",
                newName: "Item");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                column: "FavoritesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                column: "FavoritesId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3,
                column: "FavoritesId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 4,
                column: "FavoritesId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FavoritesId",
                table: "Customers",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Favorite_FavoritesId",
                table: "Customers",
                column: "FavoritesId",
                principalTable: "Favorite",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Favorite_FavoritesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FavoritesId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Favorite",
                newName: "Favorite");

            migrationBuilder.AddColumn<string>(
                name: "Favorite",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                column: "FavoritesId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                column: "FavoritesId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3,
                column: "FavoritesId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 4,
                column: "FavoritesId",
                value: 0);
        }
    }
}
