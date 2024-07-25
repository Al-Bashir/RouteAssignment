using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Static
{
    internal static class Utility
    {

        //private static double pi;
        private const double pi = 3.14;

        public static double PI
        {
            get { return pi; }
        }

        public  static double CmToInch(double cm)
        { return cm / 2.54; }

        public static  double CalcCircleArea(double r)
        {
            return PI * r * r;   
        }
    }
}
