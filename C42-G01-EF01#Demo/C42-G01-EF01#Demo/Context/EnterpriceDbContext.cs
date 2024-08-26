using C42_G01_EF01_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF01_Demo.Context
{
    internal class EnterpriceDbContext : DbContext
    {
        public DbSet<Empolyee> Empolyees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Projects> Projects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data source = .; Initial Catalog = EnterpriseDB; integrated Security = true ");
            optionsBuilder.UseSqlServer("Server = .; Database= EnterpriseDB; Trusted_Connection = true ");
        }
    }
}
