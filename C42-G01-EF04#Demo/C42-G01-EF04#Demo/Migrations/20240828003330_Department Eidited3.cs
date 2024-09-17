using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C42_G01_EF02_Demo.Migrations
{
    public partial class DepartmentEidited3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empolyees_Departments_DepartmentDeptId",
                table: "Empolyees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentDeptId",
                table: "Empolyees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empolyees_Departments_DepartmentDeptId",
                table: "Empolyees",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empolyees_Departments_DepartmentDeptId",
                table: "Empolyees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentDeptId",
                table: "Empolyees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Empolyees_Departments_DepartmentDeptId",
                table: "Empolyees",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");
        }
    }
}
