using C42_G01_EF01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF01.Configuration
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(D => D.Instructor)
                .WithOne(I => I.Department)
                .HasForeignKey<Department>(D => D.MangerId); ;

            builder.HasKey(D => D.Id);

            builder.Property(D => D.Id)
                .IsRequired()
                .UseIdentityColumn(10,2);

            builder.Property(D => D.Name)
                .IsRequired()
                .HasColumnName("DName")
                .HasMaxLength(25);

            
            builder.Property(D => D.MangerId)
                .IsRequired(false);

            builder.Property(D => D.HiringDate)
                .HasColumnType("DATE");

        }
    }
}
