using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C42_G01_EF01_Demo.Migrations
{
    public partial class UUsingDataAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Empolyees",
                newName: "PhoneNumper");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Empolyees",
                newName: "EmpId");

            migrationBuilder.AlterColumn<string>(
                name: "EmpName",
                table: "Empolyees",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Empolyees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Empolyees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Empolyees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Empolyees");

            migrationBuilder.RenameColumn(
                name: "PhoneNumper",
                table: "Empolyees",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Empolyees",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "EmpName",
                table: "Empolyees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
