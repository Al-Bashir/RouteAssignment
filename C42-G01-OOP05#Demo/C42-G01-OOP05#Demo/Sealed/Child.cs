using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Sealed
{
    internal class Child : Parent
    {
        public sealed override int Salary { get => base.Salary; set => base.Salary = value  < 5000 ? 5000 : value; }

        public sealed override void Print()
        {
            Console.WriteLine("I am child ");
        }
    }
}
