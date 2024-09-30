using C42_G01_MVC_Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_MVC_Demo.BLL.Interfaces
{
    public interface IEmpolyeeRepository : IGenericRepository<Employee> 
    {
        public IQueryable<Employee> GetEmployeesByAddress(string address);
        public IQueryable<Employee> GetEmployeesByName(string address);
    }
}
