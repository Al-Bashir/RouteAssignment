using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF02_Demo.Configuration
{
    //internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    //{
    //    public void Configure(EntityTypeBuilder<Product> E)
    //    {
    //        E.HasKey(P => P.ProductID);

    //        E.Property(E => E.ProductID)
    //        .UseIdentityColumn(10, 10);

    //        E.Property(E => E.ProductName)
    //        .HasColumnName("ProductXName")
    //        .HasColumnType("varchar")
    //        .HasMaxLength(50)
    //        .HasDefaultValue("Nounnn")
    //        .IsRequired(false);
    //    }
    //}
}
