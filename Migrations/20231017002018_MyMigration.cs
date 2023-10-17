using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafe.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "Favorite",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoritesId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    FavoritesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Favorite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.FavoritesId);
                });

            migrationBuilder.InsertData(
                table: "Favorite",
                columns: new[] { "FavoritesId", "Favorite" },
                values: new object[,]
                {
                    { 1, "Javascript Java" },
                    { 2, ".NET Decaf" },
                    { 3, "HTML Hot Cocoa" },
                    { 4, "LINQ Latte" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FavoritesId",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Address", "City", "Email", "FirstName", "GenderIdentity", "LastName", "Phone", "State", "Zip" },
                values: new object[] { 5, null, null, null, "Mark", null, "Zuckerberg", null, null, null });
        }
    }
}
