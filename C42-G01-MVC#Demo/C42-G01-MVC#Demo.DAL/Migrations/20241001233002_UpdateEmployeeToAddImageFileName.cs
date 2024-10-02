using Microsoft.EntityFrameworkCore.Migrations;

namespace C42_G01_MVC_Demo.DAL.Migrations
{
    public partial class UpdateEmployeeToAddImageFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Employees");
        }
    }
}
