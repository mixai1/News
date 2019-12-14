using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiEntity.Migrations
{
    public partial class addPositivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IndexOfPositive",
                table: "News",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndexOfPositive",
                table: "News");
        }
    }
}
