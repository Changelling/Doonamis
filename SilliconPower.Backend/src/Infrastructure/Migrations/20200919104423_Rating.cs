using Microsoft.EntityFrameworkCore.Migrations;

namespace SilliconPower.Backend.Infrastructure.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating_Score",
                table: "Assessments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating_Score",
                table: "Assessments");
        }
    }
}
