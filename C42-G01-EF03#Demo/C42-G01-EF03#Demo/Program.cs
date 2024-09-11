using C42_G01_EF03_Demo.Context;
using C42_G01_EF03_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace C42_G01_EF03_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();
            //FulltimeEmpolyee fulltimeEmpolyee = new FulltimeEmpolyee() 
            //{
            //    Name = "Ahmed",
            //    Address = "A1",
            //    Age = 1,
            //    DeptId = 1,
            //    StartDate = DateOnly.MaxValue,
            //    Salary = 1_000_000,
            //};

            //dbContext.FulltimeEmpolyees.Add(fulltimeEmpolyee);

            //dbContext.SaveChanges();


            #region Explicit Loading 
            //var FEmpolyee = (from E in dbContext.FulltimeEmpolyees
            //                 select E).FirstOrDefault();

            //dbContext.Entry(FEmpolyee).Reference(E => E.Department).Load();

            //Console.WriteLine($"Emp Name :: {FEmpolyee.Name}");
            //Console.WriteLine($"Dep Name :: {FEmpolyee.Department.Name}");

            //var Department = (from D in dbContext.Departments
            //                  select D).FirstOrDefault();
            //dbContext.Entry(Department).Collection(D => D.Employees).Load();

            //foreach (var item in Department.Employees)
            //{
            //    Console.WriteLine($"Emp Name :: {item.Address}");
            //} 
            #endregion

            #region Eager Loading
            var FEmpolyee = (from E in dbContext.FulltimeEmpolyees.Include(E => E.Department)
                             select E).FirstOrDefault();

            Console.WriteLine($"Emp Name :: {FEmpolyee.Name}");
            Console.WriteLine($"Dep Name :: {FEmpolyee.Department.Name}");

            foreach (FulltimeEmpolyee item in FEmpolyee.Department.Employees)
            {
                Console.WriteLine($"Emp Name :: {item.Salary}");
            }
            #endregion

        }
    }
}
 