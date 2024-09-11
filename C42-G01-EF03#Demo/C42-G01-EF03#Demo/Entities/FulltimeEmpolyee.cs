using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF03_Demo.Entities
{
    internal class FulltimeEmpolyee : Employee
    {
        public decimal Salary { get; set; }
        public DateOnly StartDate { get; set; }
    }
}
