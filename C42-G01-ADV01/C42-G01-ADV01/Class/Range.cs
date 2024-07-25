using C42_G01_ADV01.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV01.Class
{
    internal class Range<T> where T :  IComparable<T>, ISubtractable<T>
    {

        #region Property
        public T Minimum { get; set; }
        public T Maximum { get; set; }
        #endregion

        #region Constructor
        public Range(T minimum, T maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
        #endregion

        #region Methods
        public bool IsInRange(T value)
        {
            return value.CompareTo(Minimum) >= 0 && value.CompareTo(Maximum) <= 0;
        }

        public T Length() 
        {
            return Maximum.Substract(Minimum);
        }

        #endregion
    }
}
