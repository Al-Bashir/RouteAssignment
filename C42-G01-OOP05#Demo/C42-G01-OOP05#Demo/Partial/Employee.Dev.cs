using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Partial
{
    internal partial class Employee
    {
        public void Print () 
        {
            Console.WriteLine("I am partial Employee");
        }

        public partial void Test()
        {
            Console.WriteLine("Done");
        }
    }
}
