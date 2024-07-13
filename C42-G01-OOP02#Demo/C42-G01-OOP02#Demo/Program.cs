using System.Security.Cryptography;
using System.Xml.Serialization;
using C42_G01_OOP02_Demo.Encapsulation;
using C42_G01_OOP02_Demo.Inheritance;

namespace C42_G01_OOP02_Demo
{
    internal class Program
    {
        #region Demo #7
        static void Main()
        {
            Employee employee = new Employee(10, "Al-Bashir", salary: 10000);
            
            Console.WriteLine(employee);

            employee.Id = 20;

            //Using Getter & Setter
            employee.SetName("Al-Bashir");
            Console.WriteLine(employee.GetName());

            //Using Property 
            employee.Salary = 20000;
            Console.WriteLine(employee.Salary);

            Console.WriteLine(employee.Deduction);

            #region Indexer
            PhoneBook MyPhoneBook = new PhoneBook(3);

            #endregion

            MyPhoneBook.AddPerson(0, "Mohamed", 1234);
            MyPhoneBook.AddPerson(1, "Ali", 1234);
            MyPhoneBook.AddPerson(2, "Omar", 1234);

            MyPhoneBook.SetPersonName("Ali", 55555);

            Console.WriteLine(MyPhoneBook.GetPersonNumber("Ali"));

            Console.WriteLine(MyPhoneBook["Omar"]);


            //Class
            Car C1;
            C1 = new Car(10, "BMW", 280);

            Console.WriteLine(C1);
            
            Car C2;
            C2 = new Car(10, "BMW");

            Console.WriteLine(C2);
            
            Car C3;
            C3 = new Car(10);

            Console.WriteLine(C3);


            //Inheritance
            Parent P = new Parent(1,2);
            Console.WriteLine(P);
            Console.WriteLine(P.Product());

            Child C = new Child(3, 4, 5);
            Console.WriteLine(C);
            Console.WriteLine(C.Product());

        }
        #endregion

    }
}
