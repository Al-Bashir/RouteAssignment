using System.Collections;
using System.Linq;
using static Route_LINQ_Data_ListGenerator.ListGenerator;
using Route_LINQ_Data_ListGenerator;
using System.Text.RegularExpressions;

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
            
            Console.WriteLine("count***" + SelectResult.Count());
            foreach (var P in SelectResult )
                Console.WriteLine("Product Name***: " + P);

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
            var SelectManyResult = CustomersList.SelectMany(C => C.Orders);

            SelectManyResult = from C in CustomersList
                               from O in C.Orders
                               select O;

            Console.WriteLine("count*SelectManyResult " + SelectManyResult.Count());
            foreach (var P in SelectManyResult)
                Console.WriteLine(P);



            Console.WriteLine("=============SelectMany + spread operator================");

            var SlectMany01 = ProductsList.Where(P => P.UnitsInStock > 0).Select((P) => new
            {
                P.ProductID,
                P.ProductName,
                NewPrice = P.UnitPrice * 0.9M
            });

            //Indexed Select
            Console.WriteLine("=============SelectIndex================");
            var SelectIndexResult = ProductsList.Select((P,Index) => new { Index, P.ProductName});
            foreach (var P in SelectIndexResult)
                Console.WriteLine(P);


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
            #region Casting operators 
            List<Product> products = ProductsList.Where((P) => P.ProductID > 50).ToList();

            Dictionary<long, Product> keyValuePairs = ProductsList.Where((P) => P.UnitsInStock == 0).ToDictionary(P => P.ProductID);

            foreach (var product in keyValuePairs)
                Console.WriteLine($"Key: {product.Key}, Value:{product.Value}");
            #endregion

            #region Generation Operators 
            var RangeResult = Enumerable.Range(1, 10);
            var RangeResult2 = Enumerable.Range(5, 10);
            var RepeatResult = Enumerable.Repeat(50, 100);
            var EmptyResult = Enumerable.Empty<Product>();
            #endregion

            #region Set Operators
            var UnionResult = RangeResult.Concat(RangeResult2).Distinct();

            Console.WriteLine("==============RangeResult01====================");
            foreach (var item in RangeResult)
            {
                Console.WriteLine(item);
            }            
            Console.WriteLine("=================RangeResult02=================");
            foreach (var item in RangeResult2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=================UnionResult=================");
            foreach (var item in UnionResult)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Quantifier Operators
            Console.WriteLine("=================Quantifier Operators=================");
            Console.WriteLine(ProductsList.Any());
            Console.WriteLine(ProductsList.All(P => P.ProductID > 0));
            #endregion
            #region Zipping Operator
            var ZipinngResult = ProductsList.Zip(CustomersList);
            foreach (var item in ZipinngResult)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Grouping Operators 
            var GroupByResult = from P in ProductsList
                                group P by P.Category;
            
            Console.WriteLine($"===> GroupByResult Count: {GroupByResult.ElementAtOrDefault(1)}");
            foreach (var item in GroupByResult)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var P in item)
                Console.WriteLine($"            {P.ProductName}");
            }

            //Fluent Syntax
            var GroupByResultFluent = ProductsList.Where(P => P.UnitsInStock > 0)
                                                  .GroupBy(P => P.Category)
                                                  .Where(G => G.Count() > 10)
                                                  .Select(G => new
                                                  {
                                                      ProductCategory = G.Key,
                                                      ProductsCount = G.Count(),
                                                  });
            //Query syntax
            GroupByResultFluent = from P in ProductsList
                                  group P by P.Category
                                  into Category
                                  where Category.Count() > 10
                                  select new
                                  {
                                      ProductCategory = Category.Key,
                                      ProductsCount = Category.Count(),
                                  };
            foreach (var item in GroupByResultFluent)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Partitioning Operators
            var PartitioningResult = ProductsList.Take(10);
            PartitioningResult = ProductsList.TakeLast(10);
            PartitioningResult = ProductsList.Skip(10);
            PartitioningResult = ProductsList.SkipLast(10);
            PartitioningResult = ProductsList.TakeWhile(P => P.ProductID > 0);
            PartitioningResult = ProductsList.SkipWhile(P => P.ProductID > 0);
            foreach (var item in PartitioningResult)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Let and Into
            List<string> XNames = new List<string>() { "X1", "X2", "X3", "X4", "x5" };

            var IntoResult = from name in XNames
                             select Regex.Replace(name, "[Xx]", string.Empty)
                             into YNames
                             where YNames.Length == 1
                             select YNames;

            IntoResult = from name in XNames
                             let Ynames = Regex.Replace(name, "[Xx]", string.Empty)
                             where Ynames.Length == 1
                             select Ynames;
            Console.WriteLine("========================================================================");
            foreach (var item in IntoResult)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
