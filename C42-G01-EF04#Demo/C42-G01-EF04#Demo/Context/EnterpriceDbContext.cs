using C42_G01_EF02_Demo.Classes;
using C42_G01_EF02_Demo.Configuration;
using C42_G01_EF02_Demo.Entities;
using C42_G01_EF04_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF02_Demo.Context
{
    internal class EnterpriceDbContext : DbContext
    {
        public DbSet<Empolyee> Empolyees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EmpWithDept> EmpWithDept { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = EnterpriseDB; Trusted_Connection = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empolyee>()
                .Property(E => E.EmpName)
                .HasDefaultValue("Test")
                .IsRequired(false);

            modelBuilder.Entity<StudentCourse>()
            .HasKey(SC => new { SC.StudentId, SC.CourseId });

            modelBuilder.Entity<Student>()
            .HasMany(S => S.StudentCourses)
            .WithOne(SC => SC.Student)
            .IsRequired();

            modelBuilder.Entity<Course>()
            .HasMany(C => C.StudentCourses)
            .WithOne(SC => SC.Course)
            .IsRequired();

            modelBuilder.Entity<EmpWithDept>().ToView("EmpWithDept");

            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
