using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_LINQ01_Demo
{
    internal static class intExtension
    {
        public static int Reverse(this int Number)
        { 
            int ReversedNumber = 0;
            int LastDigit = 0;
            while (Number > 0) 
            {
                LastDigit = Number % 10;
                ReversedNumber = ReversedNumber * 10 + LastDigit;
                Number = Number / 10;
            }
            return ReversedNumber;
        }
    }
}
