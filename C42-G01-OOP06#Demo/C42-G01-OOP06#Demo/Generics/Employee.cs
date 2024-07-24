using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP06_Demo.Generics
{
    internal class Employee : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Salary}";
        }

        //Recommended works with generics 
        public override bool Equals(object? obj)
        {
            Employee? employee = (Employee?)obj;
            return (this.Id == employee?.Id) && (this.Name == employee?.Name) && (this.Salary == employee?.Salary);
        }

        public override int GetHashCode()
        {
            return (HashCode.Combine(Id.GetHashCode(), Name?.GetHashCode(), Salary.GetHashCode()));
            //return this.Id.GetHashCode() + this.Name?.GetHashCode() ?? 0 + this.Salary.GetHashCode();
        }


        public int CompareTo(object? obj)
        {
            #region MyRegion
            //Employee? PastEmployee = (Employee?)obj;
            //return Salary.CompareTo(PastEmployee?.Salary); 
            #endregion

            //#region Is conditional Operator
            //if (obj is Employee PastEmployee)
            //    return Salary.CompareTo(PastEmployee?.Salary);
            //return 1;
            //#endregion

            #region As Casting Operator
            Employee? PastEmployee = obj as Employee;
            return Salary.CompareTo(PastEmployee?.Salary)

            #endregion
        }

        //public static bool operator == (Employee a, Employee b)
        //{
        //    //return (a.Id == b.Id) && (a.Name == b.Name) && (a.Salary == b.Salary);
        //    return a.Equals(b);
        //}
        //public static bool operator != (Employee a, Employee b)
        //{
        //    //return (a.Id != b.Id) || (a.Name != b.Name) || (a.Salary != b.Salary);
        //    return !a.Equals(b);
        //}


    }
}
