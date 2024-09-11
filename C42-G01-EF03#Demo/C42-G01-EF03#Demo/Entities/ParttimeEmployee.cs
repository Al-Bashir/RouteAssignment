using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF03_Demo.Entities
{
    internal class ParttimeEmployee : Employee
    {
        public int CountOfHour { get; set; }
        public decimal HourRate { get; set; }
    }
}
