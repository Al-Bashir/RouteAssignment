using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.DL.Context;
using System;

namespace C42_G01_MVC_Demo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MVCProjectDbContext _dbContext;
        
        public IEmpolyeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public UnitOfWork(MVCProjectDbContext dbContext)
        {
            EmployeeRepository = new EmpployeeRepository(dbContext);
            DepartmentRepository = new DepartmentRepository(dbContext);
            _dbContext = dbContext;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
