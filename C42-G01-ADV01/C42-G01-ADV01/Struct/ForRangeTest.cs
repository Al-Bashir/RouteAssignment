using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C42_G01_ADV01.Interface;

namespace C42_G01_ADV01.Struct
{
    internal struct ForRangeTest : ISubtractable<ForRangeTest>, IComparable<ForRangeTest>
    {
        public int Value { get; set; }
        
        public ForRangeTest(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}"; 
        }

        public int CompareTo(ForRangeTest other)
        {
            return Value.CompareTo(other.Value);
        }

        public ForRangeTest Substract(ForRangeTest ValueToBeSubtract)
        {
            return new ForRangeTest(Value - ValueToBeSubtract.Value);
        }
    }
}
