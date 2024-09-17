using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF04_Demo.Entities
{
    [Keyless]
    internal class EmpWithDept
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
    }
}
