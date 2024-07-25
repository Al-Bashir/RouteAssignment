using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV01.Interface
{
    internal interface ISubtractable<T>
    {
         T Substract(T ValueToBeSubtract);
    }
}
