using System.Collections;
using System.Linq;
using static Route_LINQ_Data_ListGenerator.ListGenerator;

namespace C42_G01_LINQ02_Demo
{
    internal class Program
    {
        static void Main()
        {
            #region LINQ Categories 
            //LINQ 13 Categories: 
            
            //1. Filtration Operators (Differed Operators) => [where, OfType]
            ////1.1 where() operator:
            //Select all product that out of stock from Product List      
            
            //Fluent Syntax
            var OutOfStockProducts = ProductsList.Where(P => P.UnitsInStock == 0);

            //Query Syntax 
            OutOfStockProducts = from P in ProductsList
                                 where P.UnitsInStock == 0  
                                 select P;

            //Fluent Syntax
            OutOfStockProducts = ProductsList.Where(P => P.UnitsInStock > 0 && P.Category == "Meat/Poultry");

            //Query Syntax 
            OutOfStockProducts = from P in ProductsList
                                 where P.UnitsInStock > 0 && P.Category == "Meat/Poultry"
                                 select P;

            //Indexed Where() => select specific number of data not return all data
            //Indexed Where() => Only used with Fluent Syntax 
            OutOfStockProducts = ProductsList.Where((P, I) => P.UnitsInStock == 0 && I <= 20);

            OutOfStockProducts = ProductsList.Where((P, I) => P.UnitsInStock > 0 && I <= 5);

            foreach (var Product in OutOfStockProducts)
                Console.WriteLine(Product);

            Console.WriteLine("=============================");
            ////1.1 OfType() operator:
            //Filtrate the sequence base of the type of date in sequence 

            ArrayList arrayList = new ArrayList() {1, 1.6, "Ahmed", 12,6,7,"Ali", "Omar" };
            //Get all data that are string type
            var result = arrayList.OfType<string>();

            foreach (var R in result)
                Console.WriteLine(R);

            Console.WriteLine("=============Transformation Operators================");
            //2. Transformation Operators (Differed Operators) => [Select, Selectivity]
            //2.1 Select

            //Fluent Syntax
            var SelectResult = ProductsList.Select(P => P.ProductName);

            //Query Syntax
            SelectResult = from Product in ProductsList
                           select Product.ProductName;

            //Select more than one Property of Product using Anonymous Class
            //Fluent Syntax
            var SelectResult02 = ProductsList.Select(P => new {P.ProductID, P.ProductName });

            //Query Syntax
            SelectResult02 = from Product in ProductsList
                           select new { Product.ProductID, Product.ProductName };

            foreach (var P in SelectResult02)
                Console.WriteLine(P);

            Console.WriteLine("=============SelectMany================");
            //2.1 SelectMany 
            //when the sequence contain another sequence and you want to select this each sequence

            
            
            
            
            var SlectMany01 = ProductsList.Where(P => P.UnitsInStock > 0).Select((P) => new
            {
                P.ProductID,
                P.ProductName,
                NewPrice = P.UnitPrice * 0.9M
            });

            //Indexed Select
           //****// SelectResult = ProductsList.Select((P,I) => P.ProductName && I < 10);


            foreach (var P in SlectMany01)
                Console.WriteLine(P);

            

            //3. Ordering Operators 
            Console.WriteLine("=============Ordering===");
            //3.1 OrderBy()l
            var OrderingResult = ProductsList.Select(P => new { P.ProductName, P.UnitPrice }).OrderBy(P => P.UnitPrice);
            //Used for oder the items in the sequence according to specific condition

            var OrderingResult02 = from P in ProductsList
                             orderby P.UnitsInStock descending
                             select new { P.ProductName, P.UnitsInStock };
            
            //3.2ThenBy()
            //OrderBy sequence  according to condition then if more than one item match the condition use ThenBy() to Order based on another condition
            //ThenBy() can by called only on the result of OrderBy
            var OrderingResult03 = ProductsList.Select(P => new { P.ProductName, P.UnitPrice }).OrderBy(P => P.UnitPrice).ThenBy(P => P.ProductName);

            var OrderingResult04 = from p in ProductsList
                               orderby p.UnitPrice, p.ProductName
                               select new { p.ProductName, p.UnitPrice };

            foreach (var P in OrderingResult02)
                Console.WriteLine(P);

            //3.3 Reverse() return new sequence with reversed order
            //To by implemented 


            //4. Elements Operators (Immediate Execution)
            Console.WriteLine("======================Element========================");
            //4.1 First() 
            ////May through exception if the sequence is empty.

            var ElementResult = ProductsList.First();
            Console.WriteLine(ElementResult); 
            
            //4.2 Last() 
            ////May through exception if the sequence is empty.

            ElementResult = ProductsList.First();
            Console.WriteLine(ElementResult);

            //4.3 FirstOrDefault() 
            ////will not through exception if the sequence is empty but it return the default value of sequence type.

            ElementResult = ProductsList.FirstOrDefault();
            Console.WriteLine(ElementResult);

            //4.4 LastOrDefault() 
            ////will not through exception if the sequence is empty but it return the default value of sequence type.

            ElementResult = ProductsList.LastOrDefault();
            Console.WriteLine(ElementResult);

            //4.4 ElementAt() 
            //Return the element at specific index
            ////May through exception if the index out of index.
            ElementResult = ProductsList.ElementAt(1);
            Console.WriteLine(ElementResult);

            //4.4 ElementAtOrDefault() 
            //Return the element at specific index
            ElementResult = ProductsList.ElementAtOrDefault(1);
            Console.WriteLine(ElementResult);

            //4.5 Single() 
            ////May through exception if the sequence is empty or contain more than one element.
            //If the sequence contain single element it will return it, otherwise it through exception 
            
            //ElementResult = ProductsList.Single();
            Console.WriteLine(ElementResult);

            //4.6 SingleOrDefault() 
            //to be implemented 

            //4.7 DefaultIfEmpty()
            //to check the sequences is empty or not
            //to be implemented 

            //5. Aggregate() Operators (Immediate Execution) 
            //5.1 Count()
            var CountResult = ProductsList.Count(P => P.UnitsInStock == 0);

            Console.WriteLine($"Count: {CountResult}");

            //5.2 Sum()
            var SumResult = ProductsList.Sum(P => P.UnitPrice);
            Console.WriteLine($"Sum: {SumResult}");

            #endregion
        }
    }
}
