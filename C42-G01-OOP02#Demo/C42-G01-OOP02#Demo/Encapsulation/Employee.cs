using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02_Demo.Encapsulation
{
    internal struct Employee
    {
        //#region Attributes 
        //public int Id;
        //public string Name;
        //public decimal Salary; 
        //#endregion

        //#region Constructor
        //public Employee(int id, string name, decimal salary)
        //{
        //    Id = id;
        //    Name = name;
        //    Salary = salary;
        //}
        //#endregion

        //#region Methods
        //public override string ToString()
        //{
        //    return $"Id: {Id}\nName: {Name}\nSalary = {Salary:c}";
        //}
        //#endregion

        #region Encapsulation 
        #region Attributes 
        public int Id;
        private string? EmpName;
        private decimal Empsalary;
        #endregion
        public int Age { get; set; }
        #region Getter & Setter
        //Getter:
        public string? GetName()
        {
            return EmpName;
        }
        //Setter:
        public void SetName(string Value)
        {
            //Control value with specific condition(length);
            EmpName = Value?.Length > 5 ? Value.Substring(0, 5) : Value;
        }
        #endregion

        #region Using Full Property 
        public decimal Salary
        { 
            get { return Empsalary; }
            set { Empsalary = value < 30000 ? 30000 : value; }
        }        
        public decimal Deduction
        { 
            get { return Salary * 0.2M; }
        }
        
        #endregion

        #region Constructor
        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            EmpName = name;
            Salary = salary;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Id: {Id}\nName: {EmpName}\nSalary = {Salary:c}\nAge: {Age}";
        }
        #endregion
        #endregion
    }
}
