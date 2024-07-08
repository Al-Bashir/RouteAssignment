using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP01
{
    internal struct Point
    {
        public int X;
        public int Y;

        public int CalculateDistance() 
        { 
            return this.Y - this.X;   
        }
    }
}
