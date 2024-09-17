using C42_G01_EF02_Demo.Classes;
using C42_G01_EF02_Demo.Context;
using Microsoft.EntityFrameworkCore;

namespace C42_G01_EF02_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using EnterpriceDbContext DbContext = new EnterpriceDbContext();
            var QueryResult = from E in DbContext.Empolyees
                              join D in DbContext.Departments
                              on E.DepartmentDeptId equals D.DeptId
                              select new 
                              {
                                  E.EmpName,
                                  D.DeptName
                              };

            foreach (var item in QueryResult)
            {
                Console.WriteLine($"{item}");
            }

            var QueryResult02 = DbContext.Empolyees.Join(DbContext.Departments, E => E.DepartmentDeptId, D => D.DeptId, (E, D) => new { E, D }).Where(M => M.E.Salary > 1000).Select(M => new { M.E.EmpName, M.D.DeptId });

            foreach (var item in QueryResult02)
            {
                Console.WriteLine($"{item}");
            }


            foreach (var item in DbContext.EmpWithDept) 
            {
                Console.WriteLine($"{item.EmpName} :: {item.DepartmentName}");
            }

            //DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            #region MaxBy, MinBy
            var Employees = (from E in DbContext.Empolyees
                             select E).ToList();

            Console.WriteLine($"Maximum Salary {(Employees.MaxBy(E => E.Salary)).Salary}");
            Console.WriteLine($"Minimum Salary {Employees.MinBy(E => E.Salary).Salary}");
            #endregion
        }
    }
}
