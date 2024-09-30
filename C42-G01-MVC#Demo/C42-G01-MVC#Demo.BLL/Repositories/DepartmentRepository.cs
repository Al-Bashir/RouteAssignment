using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.DL.Context;
using C42_G01_MVC_Demo.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_MVC_Demo.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MVCProjectDbContext dbContext):base(dbContext) { }
    }
}
