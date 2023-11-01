using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafe.Migrations
{
    public partial class MigrationTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
