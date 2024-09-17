using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C42_G01_EF02_Demo.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductXName",
                table: "Products",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Nounnn",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmpName",
                table: "Empolyees",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Test",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductXName",
                table: "Products",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "Nounnn");

            migrationBuilder.AlterColumn<string>(
                name: "EmpName",
                table: "Empolyees",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "Test");
        }
    }
}
