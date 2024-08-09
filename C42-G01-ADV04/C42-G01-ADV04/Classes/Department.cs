using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_ADV04.Classes
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        
        List<Employee> Staff = new List<Employee>();

        public void AddStaff(Employee E)
        {
            Staff.Add(E);
            E.EmployeeLayOff += RemoveStaff;
        }

        ///CallBackMethod 
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is not null)
            { 
                Employee employee = (Employee)sender ;
                Staff.Remove(employee);
                Console.WriteLine($"Employee {employee.EmployeeID} removed from Department due to {e.Cause}");
            }
        }
    }
}
