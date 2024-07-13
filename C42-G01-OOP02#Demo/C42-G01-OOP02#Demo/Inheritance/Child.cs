using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02_Demo.Inheritance
{
    internal class Child : Parent 
    {
        public int Z { get; set; }

        public Child(int x, int y, int z):base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }

        public new int Product()
        {
            return base.Product() * this.Z;
        }
    }
}
