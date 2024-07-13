using C42_G01_OOP02.Classes;
using C42_G01_OOP02.Struct;

namespace C42_G01_OOP02
{
    internal class Program
    {
        static void Main()
        {
            #region Part 02

            #region 1- Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.
            Person[] TaskOnePersonArray = { new Person("Ahmed", 30), new Person("Ali", 40), new Person("Amr", 20) };
            for (int i = 0; i < TaskOnePersonArray.Length; i++)
                Console.WriteLine(TaskOnePersonArray[i]);
            #endregion

            #region Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
            Person TaskTwoPerson01 = new Person("Ahmed", 99);
            Person TaskTwoPerson02 = new Person("Ali", 40);
            Person TaskTwoPerson03 = new Person("Amr", 20);
            GetOldestPerson(TaskTwoPerson01, TaskTwoPerson02, TaskTwoPerson03);
            #endregion
            #endregion

            #region Part 03
            Employee[] EmployeesArrTask01 = new Employee[3];
            try
            {
                EmployeesArrTask01[0] = new Employee(1, "DBA", SecurityPrivileges.DBA, 5000, new HiringDate(1, 1, 1986), Gender.M);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            try
            {
                EmployeesArrTask01[1] = new Employee(2, "Guest", SecurityPrivileges.Gest, 10, new HiringDate(1, 1, 2010), Gender.M);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            try
            {
                EmployeesArrTask01[2] = new Employee(2, "SecurityOfficer", (SecurityPrivileges)15, 4000, new HiringDate(1, 1, 2000), Gender.M);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            SortEmployees(EmployeesArrTask01);
            #endregion
        }
        private static void GetOldestPerson(Person pOne, Person pTwo, Person pThree) 
        {
            Person OldestPerson = pOne.Age > pTwo.Age ? pOne : pTwo;
            OldestPerson = OldestPerson.Age > pThree.Age ? OldestPerson : pThree;
            Console.WriteLine($"The Oldest Person Is {OldestPerson.Name} And Has {OldestPerson.Age} Years Old.");
        }
        private static void SortEmployees(Employee[] xArray) 
        {
            Array.Sort(xArray, (x1, x2) => x1.HireDate.FullDate.CompareTo(x2.HireDate.FullDate));

            Console.WriteLine("Sorted array using Array.Sort:");
            foreach (Employee x in xArray)
            {
                Console.WriteLine($"{x} \n **Hire Date is: {x.HireDate.FullDate.ToShortDateString()} **");
            }
        }
    }
}
