using C42_G01_OOP06_Demo.Generics;

namespace C42_G01_OOP06_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Generics
            int[] Numbers = { 4, 5, 6, 7, 8, 9, 10, 7, 1 };
            //int index = Helper<int>.SearchArray(Numbers, 5);
            //Console.WriteLine(Numbers[index]);


            Employee E01 = new Employee() { Id = 10, Name="Ahmed", Salary=1000};
            Employee E02 = new Employee() { Id = 10, Name= "Ahmed", Salary=1000};
            Employee E03 = new Employee() { Id = 50, Name="Mona", Salary=6000};

            //Equals with struct => compare Object state 
            //Equals with Class => compare reference

            Console.WriteLine($"E01: {E01.GetHashCode()}");
            Console.WriteLine($"E02: {E02.GetHashCode()}");

            if (E01.Equals(E02))
                Console.WriteLine("Equal");
            else 
                Console.WriteLine("Not Equal");        
            
            if (E01 == E02)
                Console.WriteLine("Equal");
            else 
                Console.WriteLine("Not Equal");

            Employee[] employees = new Employee[3] { E01, E02, E03 };

            //Console.WriteLine(Helper<Employee>.SearchArray(employees, E01));
            #endregion

            int x = 10;
            Console.WriteLine(x.GetHashCode());

            for (int i = 0; i < Numbers.Length; i++) 
                Console.WriteLine(Numbers[i]);

            Helper<Employee>.BubbleSort(employees);
        }
    }
}
