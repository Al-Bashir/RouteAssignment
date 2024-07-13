using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02_Demo.Inheritance
{
    internal class Parent
    {
        public int X { get; set; } 
        public int Y { get; set; }

        public Parent(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region Methods
        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        public int Product()
        { 
            return this.X *this.Y;
        }
        #endregion
    }
}
