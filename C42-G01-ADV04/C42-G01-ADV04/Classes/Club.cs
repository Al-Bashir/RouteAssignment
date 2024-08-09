using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV04.Classes
{
    internal class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }

        List<Employee> Members = new List<Employee>();

        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
        }
        ///CallBackMethod 
        public void RemoveMember (object sender, EmployeeLayOffEventArgs e) 
        {
            if (sender is not null)
            {
                Employee employee = (Employee)sender;
                if (e.Cause == LayOffCause.VacationStockBelowZero)
                { 
                    Members.Remove(employee);
                    Console.WriteLine($"Employee {employee.EmployeeID} removed from Club due to {e.Cause}");
                }
            }
        }
    }
}
