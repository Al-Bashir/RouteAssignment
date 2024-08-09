using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV04.Classes
{
    internal class BoardMember : Employee
    {
        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.Resignation));
        }
    }
}
