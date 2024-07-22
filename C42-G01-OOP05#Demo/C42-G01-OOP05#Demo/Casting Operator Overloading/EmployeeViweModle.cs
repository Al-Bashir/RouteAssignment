using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05_Demo.Casting_Operator_Overloading
{
    internal class EmployeeViweModle
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public static explicit operator EmployeeViweModle(Employee E)
        {
            string[]? Names = E?.FullName?.Split(" ");
            return new EmployeeViweModle() 
            {
                Email = E?.Email,
                FirstName = Names?.Length > 0 ? Names[0] : string.Empty,
                LastName = Names?.Length > 1 ? Names[1] : string.Empty,
            };
        }
    }
}
