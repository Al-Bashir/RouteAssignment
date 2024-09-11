using C42_G01_EF03_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF03_Demo.Context
{
    internal class CompanyDbContext : DbContext
    {
        public DbSet<FulltimeEmpolyee> FulltimeEmpolyees { get; set; }
        public DbSet<ParttimeEmployee> ParttimeEmployees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = .; Database = Company; Trusted_Connection = true; trustServerCertificate = true", X => X.UseDateOnlyTimeOnly());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FulltimeEmpolyee>()
                        .HasBaseType<Employee>();

            modelBuilder.Entity<ParttimeEmployee>()
                        .HasBaseType<Employee>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
