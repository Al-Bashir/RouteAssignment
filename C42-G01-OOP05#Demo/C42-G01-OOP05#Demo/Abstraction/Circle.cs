using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Abstraction
{
    internal class Circle : Shape
    {
        public Circle(decimal dim01) : base(dim01, dim01)
        {
        }

        public override decimal Perimeter => 2 * Dim01 * (decimal)Math.PI;

        public override decimal CalcArea()
        {
            return (decimal)Math.PI * Dim01 * Dim01;
        }
    }
}
