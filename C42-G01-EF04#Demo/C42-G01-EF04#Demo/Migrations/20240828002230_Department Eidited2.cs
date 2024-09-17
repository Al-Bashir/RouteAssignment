using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C42_G01_EF02_Demo.Migrations
{
    public partial class DepartmentEidited2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "Empolyees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empolyees_DepartmentDeptId",
                table: "Empolyees",
                column: "DepartmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empolyees_Departments_DepartmentDeptId",
                table: "Empolyees",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empolyees_Departments_DepartmentDeptId",
                table: "Empolyees");

            migrationBuilder.DropIndex(
                name: "IX_Empolyees_DepartmentDeptId",
                table: "Empolyees");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "Empolyees");
        }
    }
}
