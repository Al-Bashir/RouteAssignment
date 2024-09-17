using C42_G01_EF02_Demo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF02_Demo.Entities
{
    internal class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public DateTime DOC { get; set; }
        public ICollection<Empolyee> Empolyees { get; set; } = new HashSet<Empolyee>();


    }
}
