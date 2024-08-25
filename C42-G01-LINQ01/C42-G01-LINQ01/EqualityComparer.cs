using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_LINQ01
{
    internal class EqualityComparer : IEqualityComparer<string>

    {
        public bool Equals(string? x, string? y)
        {
            return Sort(x) == Sort(y);
        }

        private string Sort(string? y)
        {
            char[] yChars = y.ToCharArray();
            Array.Sort(yChars);
            return new string(yChars);
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return Sort(obj).GetHashCode();
        }
    }
}
