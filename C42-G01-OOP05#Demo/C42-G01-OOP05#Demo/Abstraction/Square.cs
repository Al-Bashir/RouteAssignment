using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Abstraction
{
    internal class Square : RecBase 
    {
        public Square(decimal dim01) : base(dim01, dim01)
        {
        }

        public override decimal Perimeter => Dim01 * 4;

    }
}
