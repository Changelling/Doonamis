using Microsoft.EntityFrameworkCore.Migrations;

namespace SilliconPower.Backend.Infrastructure.Migrations
{
    public partial class Money : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price_Amount",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price_Currency",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Amount",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "Activities");
        }
    }
}
