using Route_LINQ_Data_ListGenerator;

namespace C42_G01_LINQ01_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Keyword that Implicitly typed local variable
            //1- var
            //2- dynamic
            var Data01 = "word";
            //var will detect the type from the initial assigned value.
            //var you can not change the type after the initialization. 
            //var can not be used as function parameter or return type. 
            //var can not initialized with null.

            //2- dynamic
            dynamic Data02 = "another word";
            //dynamic is not a data type, but it is a keyword.
            //dynamic detect the type during run-time by CLR based on the last value.
            //var can be used as function parameter or return type. 
            //you do not need to internalize the dynamic during declaration.
            //var can initialized with null, but it must be changed before any operation.
            Data02 = 5;

            #region Extension
            // Extension Method =>
            Console.WriteLine(intExtension.Reverse(123456));
            int Data03 = 7654321;
            Console.WriteLine(Data03.Reverse());
            #endregion

            #region Anonymous Type
            //Anonymous Type => if the type is used one time or not frequently you can use Anonymous Type,
            //by remove the type and use object contractor  
            var employee = new {Id = 5, Name = "Ahmed", Salary = 5000 };
            var employee02 = new {Id = 5, Name = "Ahmed", Salary = 5000 };
            var employee03 = new {Id = 5, Name = "Ahmed", Sa = 50.00 };

            Console.WriteLine(employee.GetType().Name);
            Console.WriteLine(employee02.GetType().Name);
            Console.WriteLine(employee03.GetType().Name);


            #endregion

            #region LINQ 
            //LINQ => Language Integrated Query 
            //=> +40 extension method 
            //=> used with any type of data but must be in "sequence"
            //=> "Sequence" is data structure at which the implement interface "IEnumerable"
            ////=> "Local Sequence" -> local Data stored in Memory (LINQ to Object) or data stored in file.xml (LINQ to xml). 
            ////=> "Remote Sequence" -> data stored in data base (LINQ to Entity Framework - L2EF).
            //=> used to connect to database and data in file based system.
            //=> +40 extension method can be categorized into 13 Category
            //=> LINQ Operators stored in "Enumerable" class

            List<int> Numbers = new List<int> {1, 2, 3, 4, 5, 6, 7};
            IEnumerable<int> Result = Enumerable.Where(Numbers, N => N % 2 == 0);

            foreach (int i in Result) 
                Console.WriteLine(i);

            //=> LinQ 3 main Category:
            //=> Input Sequence ----- LINQ Method -----> Output Sequence.
            //=> Input Sequence ----- LINQ Method -----> one value. ex: Any()
            //=> Input Void ----- LINQ Method -----> Output Sequence. ex: Range()

            #endregion

            #region LINQ Syntax
            //1. Fluent Syntax
            ////using through object member method (extension method) #Recommended.
            ////using through class member method => Enumerable
            List<int> ints = new List<int>() {1,2,3,4,5,6,7 };
            IEnumerable<int> IntsResult = Enumerable.Where(ints, N => N % 2 == 0);

            foreach (int i in IntsResult)
                Console.WriteLine(i);

            IEnumerable<int> IntsResultExtinsion = ints.Where(N => N % 3 == 0);
            foreach (int i in IntsResult)
                Console.WriteLine(i);

            //2. Query Syntax #SQL style [Recommended when required to use join, group by, let, into]
            ////using by start with keyword "from" and end with "select or group by"
            List<int> ints01 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<int> IntsResult01 = from N in ints01
                                            where N % 2 == 0
                                            select N;
            foreach (int i in IntsResult01)
                Console.WriteLine(i);
            #endregion

            #region LINQ categories based on Execution Way 
            //1. Methods with Differed Execution Way : 10 categories
            
            //ex: where() is a Differed Method not Executed is this line. 
            IEnumerable<int> Result02 = Enumerable.Where(Numbers, N => N % 2 == 0);
            // "Result02" variable will include 10, 12 because the where is not executed until now
            Numbers.AddRange(new int[] { 9,10,11,12,13 }); 
            // Here is the actual Execution of where() when the "Result02" variable is used. 
            foreach (int i in Result02) 
                Console.WriteLine(i);

            //2. Methods with Immediate Execution Way : 3 categories [Elements - Casting - Aggregate]
            //ex: ToList() is a Immediate Method Executed is this line. 
            List<int> Result03 = Enumerable.Where(Numbers, N => N % 2 == 0).ToList();
            // "Result03" variable will not include 14, 16 because the ToList() executed immediately
            Numbers.AddRange(new int[] { 14,15,16,17});

                Console.WriteLine("===============================");
            foreach (int i in Result03)
                Console.WriteLine(i);

            #endregion

            #region LINQ 13 categories
            Console.WriteLine("************************************");
             
            for (int i = 0; i < ListGenerator.CustomersList.Count; i++)
                Console.WriteLine(ListGenerator.CustomersList[i]);
            #endregion
        }
    }
}
