using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV04.Classes
{
    internal class EmployeeLayOffEventArgs 
    {
        public LayOffCause Cause { get; set; }
        public EmployeeLayOffEventArgs(LayOffCause cause)
        {
            Cause = cause;
        }

    }
}
