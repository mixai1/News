using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiEntity.Migrations
{
    public partial class addnullpositivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "IndexOfPositive",
                table: "News",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "IndexOfPositive",
                table: "News",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
