using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafe.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Item_FavoritesId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Favorites");

            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Favorites",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Favorites_FavoritesId",
                table: "Customers",
                column: "FavoritesId",
                principalTable: "Favorites",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Favorites_FavoritesId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Item");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Item",
                newName: "Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Item_FavoritesId",
                table: "Customers",
                column: "FavoritesId",
                principalTable: "Item",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
