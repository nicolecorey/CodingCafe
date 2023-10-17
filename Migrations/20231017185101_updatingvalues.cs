using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafe.Migrations
{
    public partial class updatingvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Favorite_FavoritesId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite");

            migrationBuilder.RenameTable(
                name: "Favorite",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Item_FavoritesId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Favorite");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorite",
                table: "Favorite",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Favorite_FavoritesId",
                table: "Customers",
                column: "FavoritesId",
                principalTable: "Favorite",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
