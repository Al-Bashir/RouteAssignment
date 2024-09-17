using DatabaseFirst.WizardContext;
using DatabaseFirst.WizardModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindWizardContext DbContext = new NorthwindWizardContext();
            var Categories = DbContext.Categories.FromSqlRaw("SELECT * FROM Categories");

            foreach (var category in Categories) 
            {
                Console.WriteLine(category);
            }

            //DbContext.Products.Load();
            if (DbContext.Products.Local.Any(P => P.UnitsInStock == 0)) 
                Console.WriteLine("Out of stock from local");
            else if (DbContext.Products.Any(P => P.UnitsInStock == 0)) 
                Console.WriteLine("Out of stock from database query");

            var result = DbContext.Categories.Find(1);

            Console.WriteLine(result);
        }
    }
}
