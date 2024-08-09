using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV04.Classes
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public int VacationStock { get; set; }
        public DateTime BirthDate { get; set; }


        public bool RequestVacation(DateTime From, DateTime To)
        {
            int daysRequested = (To - From).Days;
            if (VacationStock >= daysRequested)
            {
                VacationStock -= daysRequested;
                return true;
            }
            return false;
        }

        public void EndOfYearOperation()
        {
            if (VacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.VacationStockBelowZero));
            }
            else if ((DateTime.Now.Year - BirthDate.Year) > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.AgeAboveSixty));
            }
        }


        #region Methods
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
        #endregion

        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
    }
}
