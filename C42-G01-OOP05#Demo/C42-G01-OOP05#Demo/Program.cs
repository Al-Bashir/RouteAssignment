using C42_G01_OOP05_Demo.Abstraction;
using C42_G01_OOP05_Demo.Casting_Operator_Overloading;
using C42_G01_OOP05_Demo.Operator_Overloading;

namespace C42_G01_OOP05_Demo
{
    internal class Program
    {
        static void Main()
        {
            #region Operator Overloading
            Complex C1 = new Complex() { Real = 3, Imag = 5 };
            Console.WriteLine(C1);            
            
            Complex C2 = new Complex() { Real = 2, Imag = 4 };
            Console.WriteLine(C2);

            Complex C3 = C1 + C2; 
            Console.WriteLine(C3);

            C3++;

            Console.WriteLine($"C3++: {C3}");

            if (C1 > C2)
                Console.WriteLine("C1 > C2");
            else
                Console.WriteLine("C1 < C2");

            #endregion

            #region Casting Operator Overloading 
            Complex C4 = new Complex() { Real = 2, Imag = 9 };

            int y = (int)C4;

            Console.WriteLine(y);

            string S1 = C4;

            Employee employee = new Employee() 
            {
                Id = 1,
                FullName = "S1",
                Email = "a@a.net",
                Password = "Password",
                SecurityStamp = Guid.NewGuid()
            };

            EmployeeViweModle employeeViweModle = new EmployeeViweModle();

            employeeViweModle = (EmployeeViweModle)employee;

            Console.WriteLine(employeeViweModle.FirstName);
            Console.WriteLine(employeeViweModle.LastName);
            #endregion

            #region Abstraction
            Rec rec = new Rec(10, 20);
            Console.WriteLine(rec.CalcArea());
            Console.WriteLine(rec.Perimeter);

            Circle circle = new Circle(30);
            Console.WriteLine(circle.CalcArea());
            Console.WriteLine(circle.Perimeter);
            #endregion
        }
    }
}
