using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC_Demo.DL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_MVC_Demo.BLL.Repositories
{
    public class EmpployeeRepository : GenericRepository<Employee>, IEmpolyeeRepository
    {
        private readonly MVCProjectDbContext _dbContext;

        public EmpployeeRepository(MVCProjectDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return _dbContext.Employees.Where(E => E.Address == address);
        }

        public IQueryable<Employee> GetEmployeesByName(string name)
        {
            return _dbContext.Employees.Include(E => E.Department).Where(E => E.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
