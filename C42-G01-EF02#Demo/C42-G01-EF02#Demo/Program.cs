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

            //CRUD 
            //Empolyee Emp01 = new Empolyee() 
            //{
            //    EmpName = "Ahmed",
            //    Age = 55,
            //    Salary = 4_000,
            //    Email = "Ahmed@a.com",
            //    Password = "password",
            //    PhoneNumper = "01234566789"
            //};
            //Empolyee Emp02 = new Empolyee()
            //{
            //    EmpName = "Ali",
            //    Age = 44,
            //    Salary = 4_000,
            //    Email = "Ali@a.com",
            //    Password = "password",
            //    PhoneNumper = "01234566789"
            //};

            //Console.WriteLine(DbContext.Entry(Emp01).State);

            //DbContext.Empolyees.Add(Emp01);
            //DbContext.Empolyees.Add(Emp02);

            //Console.WriteLine(DbContext.Entry(Emp01).State);

            //DbContext.SaveChanges();
            //Console.WriteLine(DbContext.Entry(Emp01).State);

            //Console.WriteLine($"Emp1 Id: {Emp01.EmpId}");
            //Console.WriteLine($"Emp2 Id: {Emp02.EmpId}");

            //var REmp01 = (from E in DbContext.Empolyees
            //             where E.EmpId == 1
            //             select E).FirstOrDefault();

            //Console.WriteLine($"Emp2 Name: {REmp01?.EmpName ?? "Not Found"}");

            //var REmp01 = (from E in DbContext.Empolyees
            //              where E.EmpId == 1
            //              select E).FirstOrDefault();

            //Console.WriteLine(DbContext.Entry(REmp01).State);
            //REmp01.EmpName = "Z3bola";
            //Console.WriteLine(DbContext.Entry(REmp01).State);
            //DbContext.SaveChanges();
            //Console.WriteLine(DbContext.Entry(REmp01).State);
            //DbContext.Empolyees.Remove(REmp01);
            //Console.WriteLine(DbContext.Entry(REmp01).State);
            //DbContext.SaveChanges();
            //Console.WriteLine(DbContext.Entry(REmp01).State);
        }
    }
}
