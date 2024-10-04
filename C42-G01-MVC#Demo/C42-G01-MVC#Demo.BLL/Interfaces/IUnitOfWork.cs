using C42_G01_MVC_Demo.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_MVC_Demo.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmpolyeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository{ get; set; }
        public Task<int> CompleteAsync();
    }
}
