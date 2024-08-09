using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV04.Classes
{
    internal class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }

        public bool CheckTarget(int quota)
        {
            return AchievedTarget >= quota;
        }

        public void EndOfYearOperation(int quota)
        {
            if (!CheckTarget(quota))
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.FailedSalesTarget));
            }
        }
    }
}
