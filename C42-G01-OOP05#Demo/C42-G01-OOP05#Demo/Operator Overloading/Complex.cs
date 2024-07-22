using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Operator_Overloading
{
    internal class Complex
    {
        public int Real { get; set; }
        public int Imag { get; set; }

        public override string ToString()
        {
            return $"{Real} + {Imag}i";
        }

        #region Operator Overloading 
        public static Complex operator + (Complex a, Complex b) 
        {
            return new Complex()
            {
                Real = (a?.Real ?? 0) + (b?.Real ?? 0),
                Imag = (a?.Imag ?? 0) + (b?.Imag ?? 0)
            };
        }

        public static Complex operator ++ (Complex a)
        {
            return new Complex()
            {
                Real = (a?.Real ?? 0) + 1,
                Imag = (a?.Imag ?? 0) 
            };
        }

    public static bool operator > (Complex left, Complex right) 
    {
        if (left?.Real == right?.Real)

            return left?.Imag > right?.Imag;
        else
            return left.Real > right?.Real;
    }        
    public static bool operator < (Complex left, Complex right) 
    {
        if (left?.Real == right?.Real)

            return left?.Imag < right?.Imag;
        else
            return left.Real < right?.Real;
    }

        public static explicit operator int(Complex C)
        { 
            return C?.Real ?? 0;
        }        
        public static implicit operator string(Complex C)
        { 
            return C?.ToString() ?? string.Empty;
        }

        #endregion
    }
}
