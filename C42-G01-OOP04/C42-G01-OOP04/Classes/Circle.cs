using C42_G01_OOP04.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP04.Classes
{
    internal class Circle : ICircle
    {

        public int Area { get; set; }

        public Circle(int area)
        {
            Area = area;
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"The Area of the Circle is: {Area} m^3");
        }
    }
}
