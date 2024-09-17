using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C42_G01_EF02_Demo.Migrations
{
    public partial class RunSQLScriptForCreatingView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW EmpWithDept 
                                 WITH ENCRYPTION
                                 As
                                 	 SELECT E.EmpId, E.EmpName, D.DeptId, D.DepartmentName  
                                     FROM Empolyees E, Departments D
                                 	 WHERE E.DepartmentDeptId = D.DeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW EmpWithDept");
        }
    }
}
