using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Abstraction
{
    internal class Rec : RecBase
    {
        public Rec(decimal dim01, decimal dim02) : base(dim01, dim02)
        {
        }

        public override decimal Perimeter => (Dim02 + Dim01) * 2;

    }
}
