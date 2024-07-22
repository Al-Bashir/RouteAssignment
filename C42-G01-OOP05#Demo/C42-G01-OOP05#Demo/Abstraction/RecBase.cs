using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Abstraction
{
    internal abstract class RecBase : Shape
    {
        protected RecBase(decimal dim01, decimal dim02) : base(dim01, dim02)
        {
        }

        public override decimal CalcArea()
        {
            return Dim01 * Dim02;
        }
    }
}
