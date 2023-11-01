using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafe.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderIdentity",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderIdentity",
                table: "Customers",
                type: "int",
                nullable: true);
        }
    }
}
