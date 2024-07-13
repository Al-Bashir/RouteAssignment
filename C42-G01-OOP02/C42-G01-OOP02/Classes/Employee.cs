using C42_G01_OOP02.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02.Classes
{
    #region Enum
    enum Gender
    {
        M = 0,
        Male = 0,
        F = 1,
        Female = 1,
    }
    [Flags]
    enum SecurityPrivileges
    {
        Gest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8
    } 
    #endregion
    internal class Employee
    {
        #region Properties
        private int id;

        public int Id
        {
            get { return id; }
            set 
            { 
                if (value > 0)
                    id = value;
                else
                    throw new Exception("Id is not valid");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set 
            {
                if (value is not null)
                    name = value;
                else
                    throw new Exception("Name is not valid");
            }
        }

        private SecurityPrivileges securityLevel;

        public SecurityPrivileges SecurityLevel
        {
            get { return securityLevel; }
            set 
            { 
                if (value > 0 && value <= (SecurityPrivileges)15) 
                    securityLevel = value;
                else
                    throw new Exception("SecurityPrivileges is not valid");
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set 
            {
                if (value > 0)
                    salary = value;
                else
                    throw new Exception("Salary is not valid");
            }
        }

        private HiringDate hireDate;

        public HiringDate HireDate
        {
            get { return hireDate; }
            set 
            {
                if (value is not null && value is HiringDate)
                    hireDate = value;
                else 
                    throw new Exception("Hire Date is not valid");
            }
        }

        private Gender gender;


        public Gender Gender
        {
            get { return gender; }
            set 
            {
                if (value == (Gender)0 || value == (Gender)1)
                    gender = value;
                else
                    throw new Exception ("Gender in not valid");
            }
        }

        #endregion
        public Employee(int id, string name, SecurityPrivileges securityLevel, int salary, HiringDate hiringDate, Gender gender)
        {
            Id = id;
            Name = name;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hiringDate;
            Gender = gender;
        }

        #region Methods
        public override string ToString()
        {
            string EmployeeData = String.Format(
                "Employee Id {0},\n" +
                "Employee Name {1},\n" +
                "Employee Salary {2:c}\n" +
                "Employee Permission {3}",
                Id, Name, Salary, SecurityLevel);
            return EmployeeData;
        }
        #endregion
    }
}
