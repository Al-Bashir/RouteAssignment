using C42_G01_MVC_Demo.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_MVC_Demo.DL.Context
{
    public class MVCProjectDbContext : DbContext
    {
        public MVCProjectDbContext(DbContextOptions<MVCProjectDbContext> options):base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server = .; Database = MVCProjectDB; Trusted_Connection = true;");


        public DbSet<Department> Departments { get; set; }
    }
}
