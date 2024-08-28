using C42_G01_EF02_Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF02_Demo.Configuration
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(D => D.Empolyees)
                .WithOne(E => E.Department)
                .HasForeignKey(E => E.DepartmentDeptId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(D => D.DeptId);

            builder.Property(D => D.DeptId)
                .UseIdentityColumn(10, 10);

            builder.Property(D => D.DeptName)
                .HasColumnName("DepartmentName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}
