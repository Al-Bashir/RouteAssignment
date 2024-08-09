using C42_G01_ADV04.Classes;

namespace C42_G01_ADV04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department dept = new Department() { DeptID = 1, DeptName = "IT" };
            Club club = new Club() { ClubID = 1, ClubName = "Health Club" };

            Employee employee = new Employee() { EmployeeID = 101, BirthDate = new DateTime(1950, 1, 1), VacationStock = -5 };
            SalesPerson salesperson = new SalesPerson() { EmployeeID = 102, AchievedTarget = 50 };
            BoardMember boardMember = new BoardMember() { EmployeeID = 103 };

            dept.AddStaff(employee);
            dept.AddStaff(salesperson);
            dept.AddStaff(boardMember);

            club.AddMember(employee);
            club.AddMember(salesperson);
            club.AddMember(boardMember);

            employee.EndOfYearOperation();
            salesperson.EndOfYearOperation(100);
            boardMember.Resign();

        }
    }
}
