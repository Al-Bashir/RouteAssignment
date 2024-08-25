using Route_LINQ_Data_ListGenerator;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Threading;
using static Route_LINQ_Data_ListGenerator.ListGenerator;

namespace C42_G01_LINQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators
            //1. Find all products that are out of stock.
            var Result00 = ProductsList.Where(P => P.UnitsInStock == 0);
            Console.WriteLine("----> products that are out of stock");
            foreach (var item in Result00)
            {
                Console.WriteLine(item);
            }

            //2. Find all products that are in stock and cost more than 3.00 per unit.
            var Result01 = ProductsList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 3);
            Console.WriteLine("----> products that are in stock and cost more than 3.00 per unit");
            foreach (var item in Result01)
            {
                Console.WriteLine(item);
            }

            //3. Returns digits whose name is shorter than their value.
            Console.WriteLine("----> Returns digits whose name is shorter than their value");
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result03 = Arr.Where((P, I) => P.Length < I);
            foreach (var item in Result03)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region LINQ - Element Operators
            //1. Get first Product out of Stock 
            Console.WriteLine("----> Get first Product out of Stock ");
            var Result10 = ProductsList.FirstOrDefault(P => P.UnitsInStock == 0);
            Console.WriteLine(Result10);

            //2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            Console.WriteLine("---->  Return the first product whose Price > 1000, unless there is no match, in which case null is returned.");
            var Result11 = ProductsList.FirstOrDefault(P => P.UnitPrice > 1000);
            Console.WriteLine(Result11);

            //3. Retrieve the second number greater than 5 
            int[] ArrInt = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("---->  3. Retrieve the second number greater than 5 ");
            var Result12 = ArrInt.Where(P => P > 5).ElementAtOrDefault(1);
            Console.WriteLine(Result12);

            #endregion

            #region LINQ - Aggregate Operators
            //1. Uses Count to get the number of odd numbers in the array
            int[] AggregateArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("---->  Uses Count to get the number of odd numbers in the array");
            var Result20 = AggregateArr.Count(P => P % 2 != 0);
            Console.WriteLine(Result20);

            //2. Return a list of customers and how many orders each has.
            Console.WriteLine("---->  2. Return a list of customers and how many orders each has.");
            var Result21 = CustomersList.Select(P => new
            {
                Customer = P,
                OrederCount = P.Orders.Count()
            });
            foreach (var item in Result21)
            {
                Console.WriteLine(item.Customer);
                Console.WriteLine($"Order Count: {item.OrederCount}");
            }

            //3. Return a list of categories and how many products each has
            Console.WriteLine("---->  3. Return a list of categories and how many products each has");
            var Result22 = ProductsList.GroupBy(P => P.Category)
                                        .Select(G => new
                                        {
                                            Category = G.Key,
                                            ProcuctCount = G.Count()
                                        });
            foreach (var item in Result22)
            {
                Console.WriteLine(item.Category);
                Console.WriteLine($"Product Count: {item.ProcuctCount}");
            }

            //4. Get the total of the numbers in an array.
            Console.WriteLine("---->  4. Get the total of the numbers in an array.");
            int[] ArrResult23 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result23 = ArrResult23.Sum();
            Console.WriteLine($"Sum: {Result23}");

            //5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            Console.WriteLine("---->  5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).");
            var Result24 = Regex.Replace(File.ReadAllText("dictionary_english.txt"), " ", string.Empty).Length;
            Console.WriteLine($"Total number of characters : {Result24}");

            //6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            Console.WriteLine("---->  6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).");
            var Result25 = File.ReadAllText("dictionary_english.txt")
                               .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                               .Min(x => x.Length);
            Console.WriteLine($" Get the length of the shortest word : {Result25}");

            //7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            Console.WriteLine("---->  7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).");
            var Result26 = File.ReadAllText("dictionary_english.txt")
                               .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                               .Max(x => x.Length);

            Console.WriteLine($" Get the length of the Max word : {Result26}");

            //8.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            Console.WriteLine("---->  8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).");
            var Result27 = File.ReadAllText("dictionary_english.txt")
                               .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                               .Average(x => x.Length);

            Console.WriteLine($" Get the Average length of the word : {Result27}");

            //9. Get the total units in stock for each product category.
            Console.WriteLine("---->  9. Get the total units in stock for each product category.");
            var Result28 = ProductsList.GroupBy(P => P.Category);
            foreach (var result in Result28)
            {
                Console.WriteLine($"Category: {result.Key}");
                Console.WriteLine(result.Sum(P => P.UnitsInStock));
            }

            //10. Get the cheapest price among each category's products
            Console.WriteLine("---->  10. Get the cheapest price among each category's products");
            var Result29 = ProductsList.GroupBy(P => P.Category);
            foreach (var result in Result29)
            {
                Console.WriteLine($"Category: {result.Key}");
                Console.WriteLine(result.Min(P => P.UnitPrice));
            }

            //11. Get the products with the cheapest price in each category (Use Let)
            Console.WriteLine("---->  11. Get the products with the cheapest price in each category (Use Let)");
            var Result210 = from P in ProductsList
                            group P by P.Category
                             into Catigories
                            let MinProductPrice = Catigories.Min(P => P.UnitPrice)
                            select new
                            {
                                Catigories.Key,
                                MinProductPrice
                            };

            foreach (var result in Result210)
            {
                Console.WriteLine($"Category: {result.Key}");
                Console.WriteLine(result.MinProductPrice);
            }

            //12. Get the most expensive price among each category's products.
            Console.WriteLine("---->  12. Get the most expensive price among each category's products.");
            var Result211 = ProductsList.GroupBy(P => P.Category);
            foreach (var result in Result211)
            {
                Console.WriteLine($"Category: {result.Key}");
                Console.WriteLine(result.Max(P => P.UnitPrice));
            }

            //13. Get the products with the most expensive price in each category.
            Console.WriteLine("----> 13. Get the products with the most expensive price in each category.");
            var Result212 = from P in ProductsList
                            group P by P.Category
                            into Catigories
                            let MaxProductPrice = Catigories.Max(P => P.UnitPrice)
                            from Product in Catigories
                            where Product.UnitPrice == MaxProductPrice
                            select new
                            {
                                Catigories.Key,
                                Product
                            };

            foreach (var result in Result212)
            {
                Console.WriteLine($"Category: {result.Key}");
                Console.WriteLine(result.Product);
            }

            //14. Get the average price of each category's products.
            Console.WriteLine("----> 14. Get the average price of each category's products.");
            var Result213 = from P in ProductsList
                            group P by P.Category
                            into Catigories
                            let AvaProductPrice = Catigories.Average(P => P.UnitPrice)
                            select new
                            {
                                Catigories.Key,
                                AvaProductPrice
                            };

            foreach (var result in Result213)
            {
                Console.WriteLine($"Category: {result.Key}");
                Console.WriteLine(result.AvaProductPrice);
            }
            #endregion

            #region LINQ - Ordering Operators
            //1. Sort a list of products by name
            var Result30 = ProductsList.OrderBy(P => P.ProductName);
            Console.WriteLine("----> Sort a list of products by name");
            foreach (var item in Result30)
            {
                Console.WriteLine(item);
            }

            //2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            Console.WriteLine("----> Uses a custom comparer to do a case-insensitive sort of the words in an array.");
            string[] Arr31 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result31 = Arr31.OrderBy(P => P, new CaseInsensitive());
            foreach (var item in Result31)
            {
                Console.WriteLine(item);
            }

            //3. Sort a list of products by units in stock from highest to lowest.
            Console.WriteLine("----> 3. Sort a list of products by units in stock from highest to lowest.");
            var Result32 = from P in ProductsList
                           orderby P.UnitPrice descending
                           select P;

            foreach (var item in Result32)
            {
                Console.WriteLine(item);
            }

            //4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            Console.WriteLine("----> 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.");
            string[] Arr33 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result33 = Arr33.OrderBy(P => P.Length).ThenBy(P => P);
            foreach (var item in Result33)
            {
                Console.WriteLine(item);
            }

            //5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            Console.WriteLine("----> 5. Sort first by-word length and then by a case-insensitive sort of the words in an array.");
            string[] Arr34 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result34 = Arr34.OrderBy(P => P.Length).ThenBy(P => P, StringComparer.OrdinalIgnoreCase);
            foreach (var item in Result34)
            {
                Console.WriteLine(item);
            }

            //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            Console.WriteLine("----> 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.\r\n");
            var Result35 = ProductsList.OrderByDescending(P => P.Category).ThenByDescending(P => P.UnitPrice);
            foreach (var item in Result35)
            {
                Console.WriteLine(item);
            }

            //7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            Console.WriteLine("----> 7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.");
            string[] Arr36 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result36 = Arr36.OrderBy(P => P.Length).ThenByDescending(P => P, StringComparer.OrdinalIgnoreCase);
            foreach (var item in Result34)
            {
                Console.WriteLine(item);
            }

            //8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            Console.WriteLine("----> 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.");
            string[] Arr37 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result37 = Arr37.Reverse().Where(P => P[1] == 'i');
            foreach (var item in Result37)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region LINQ – Transformation Operators
            //1. Return a sequence of just the names of a list of products.
            Console.WriteLine("---->  1. Return a sequence of just the names of a list of products.");
            var Result40 = ProductsList.Select(P => P.ProductName);
            foreach (var item in Result40)
                Console.WriteLine(item);

            //2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            Console.WriteLine("---->  2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).");
            string[] Arr41 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var Result41 = Arr41.Select(P => new
            {
                UpperCase = P.ToUpper(),
                LowerCase = P.ToLower()
            });
            foreach (var item in Result41)
                Console.WriteLine(item);

            //3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            Console.WriteLine("---->  3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.");
            var Result42 = ProductsList.Select(P => new
            {
                P.ProductName,
                Price = P.UnitPrice,
            });
            foreach (var item in Result41)
                Console.WriteLine(item);

            //4. Determine if the value of int in an array matches their position in the array.
            Console.WriteLine("---->  4. Determine if the value of int in an array matches their position in the array.");
            int[] Arr43 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result43 = Arr43.Select((P, I) => new
            {
                Number = P,
                Status = P == I
            });
            Console.WriteLine("Number: In-Place?");
            foreach (var item in Result43)
                Console.WriteLine($"{item.Number}: {item.Status}");

            //5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            Console.WriteLine("---->  5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.");
            int[] Arr44A = { 0, 2, 4, 5, 6, 8, 9 };
            int[] Arr44B = { 1, 3, 5, 7, 8 };
            var Result44 = from N1 in Arr44A
                           from N2 in Arr44B
                           where N1 < N2
                           select new 
                           {
                                N1 = N1,
                                N2 = N2
                           };
            Console.WriteLine("Pairs where a < b: ");
            foreach (var item in Result44)
                Console.WriteLine($"{item.N1} is less than {item.N2}");

            //6. Select all orders where the order total is less than 500.00.
            Console.WriteLine("-------> 6. Select all orders where the order total is less than 500.00.");
            var Result45 = from L in CustomersList
                           select L.Orders into Orders
                           where Orders.Sum(P => P.Total) < 500
                           select Orders;

            foreach (var item in Result45)
            {
                Console.WriteLine($"{item}");
                foreach (var order in item)
                    Console.WriteLine($"{order}");
            }

            //7. Select all orders where the order was made in 1998 or later.
            Console.WriteLine("-------> 7. Select all orders where the order was made in 1998 or later.");
            var Result46 = from L in CustomersList
                           select L.Orders into Orders
                           from Order in Orders
                           where Order.OrderDate.Year >= 1998
                           select Order;

            foreach (var item in Result46)
            {
                Console.WriteLine($"{item}");
            }
            #endregion

            #region LINQ - Set Operators
            //1. Find the unique Category names from Product List
            Console.WriteLine("-------> 1. Find the unique Category names from Product List");
            var Result50 = ProductsList.Select(P => P.Category).Distinct();
            foreach (var item in Result50)
            {
                Console.WriteLine($"{item}");
            }

            //2. Produce a Sequence containing the unique first letter from both product and customer names.
            Console.WriteLine("-------> 2. Produce a Sequence containing the unique first letter from both product and customer names.");
            var Result51 = Enumerable.Union(
                (ProductsList.Select(P => P.ProductName[0])), 
                (CustomersList.Select(P => P.CustomerName[0])));
            
            foreach (var item in Result51)
            {
                Console.WriteLine($"{item}");
            }

            //3. Create one sequence that contains the common first letter from both product and customer names.
            Console.WriteLine("-------> 3. Create one sequence that contains the common first letter from both product and customer names.");
            var Result52 = Enumerable.Intersect(
                (ProductsList.Select(P => P.ProductName[0])), 
                (CustomersList.Select(P => P.CustomerName[0])));

            foreach (var item in Result52)
            {
                Console.WriteLine($"{item}");
            }

            //5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            Console.WriteLine("-------> 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates");
            var Result53 = Enumerable.Concat(
                (ProductsList.Select(P => P.ProductName.TakeLast(3))), 
                (CustomersList.Select(P => P.CustomerName.TakeLast(3))));

            foreach (var item in Result53)
            {
                Console.WriteLine($"{item}");
            }
            #endregion

            #region LINQ - Partitioning Operators
            //1. Get the first 3 orders from customers in Washington
            Console.WriteLine("-------> 1. Get the first 3 orders from customers in Washington");
            var Result54 = CustomersList.Where(C => C.City == "Washington").Select(O => new
            { 
                CustomerId= O.CustomerID,
                Orders = O.Orders.Take(3)
            });

            foreach (var item in Result54)
            {
                Console.WriteLine($"{item.CustomerId}");
                foreach (var order in item.Orders)
                    Console.WriteLine(order);
            }

            //2. Get all but the first 2 orders from customers in Washington
            Console.WriteLine("-------> 2. Get all but the first 2 orders from customers in Washington");
            var Result55 = CustomersList.Where(C => C.City == "Washington").Select(O => new
            {
                CustomerId = O.CustomerID,
                Orders = O.Orders.Skip(2)
            });

            foreach (var item in Result54)
            {
                Console.WriteLine($"{item.CustomerId}");
                foreach (var order in item.Orders)
                    Console.WriteLine(order);
            }

            //3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            Console.WriteLine("-------> 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.");
            int[] Arr56 = { 1, 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result56 = Arr56.TakeWhile((E, I) => E >= I);

            foreach (var item in Result56)
            {
                Console.WriteLine(item);
            }

            //4.Get the elements of the array starting from the first element divisible by 3.
            Console.WriteLine("-------> 4.Get the elements of the array starting from the first element divisible by 3.");
            int[] Arr57 = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result57 = Arr57.SkipWhile(E => (E % 3) != 0);
            foreach (var item in Result57)
            {
                Console.WriteLine(item);
            }

            //5. Get the elements of the array starting from the first element less than its position.
            Console.WriteLine("-------> 5. Get the elements of the array starting from the first element less than its position.");
            int[] Arr58 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result58 = Arr58.SkipWhile((E, I) => E >= I);
            foreach (var item in Result58)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region LINQ - Quantifiers
            //1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            Console.WriteLine("-------> 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.");
            var Result60 = File.ReadAllText("dictionary_english.txt").Split(" ").ToList().Any(W => W.Contains("ei"));
            Console.WriteLine(Result60);

            //2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
            Console.WriteLine("-------> 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.");
            var Result61 = from P in ProductsList
                           group P by P.Category into Categories
                           where Categories.Any(P => P.UnitsInStock == 0)
                           select Categories;

            foreach (var item in Result61)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var p in item)
                    Console.WriteLine(p);
            }

            //3. Return a grouped a list of products only for categories that have all of their products in stock.
            Console.WriteLine("-------> 3. Return a grouped a list of products only for categories that have all of their products in stock.");
            var Result62 = from P in ProductsList
                           group P by P.Category into Categories
                           where Categories.Any(P => P.UnitsInStock != 0)
                           select Categories;

            foreach (var item in Result62)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var p in item)
                    Console.WriteLine(p);
            }
            #endregion

            #region LINQ – Grouping Operators
            //1. Use group by to partition a list of numbers by their remainder when divided by 5
            Console.WriteLine("-------> 1. Use group by to partition a list of numbers by their remainder when divided by 5");
            int[] Arr70 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var Result70 = Arr70.GroupBy(E => (E % 5));

            foreach (var item in Result70)
            {
                Console.WriteLine($"Numbers with reminder of {item.Key} when divided with 5");
                foreach(var p in item)
                    Console.WriteLine(p);
            }

            //2. Uses group by to partition a list of words by their first letter.
            Console.WriteLine("-------> 2. Uses group by to partition a list of words by their first letter.");
            var Result71 = File.ReadAllText("dictionary_english.txt").Split(" ").ToList().GroupBy(W => W[0]);
            foreach (var item in Result71)
            {
                Console.WriteLine($"Letter: {item.Key}");
            }

            //3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            Console.WriteLine("-------> 3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together");
            string[] Arr72 = { "from", "salt", "earn", " last", "near", "form" };
            var Result72 = Arr72.GroupBy(E => E.Trim(), new EqualityComparer());

            foreach (var item in Result72)
            {
                foreach (var p in item)
                    Console.WriteLine(p);

                Console.WriteLine("---------------");
            }
            #endregion
        }
    }
}
