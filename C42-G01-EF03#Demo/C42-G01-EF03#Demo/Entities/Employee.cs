using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF03_Demo.Entities
{
    internal abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }
    }
}
