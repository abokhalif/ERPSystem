using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.AppConfigurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(D => D.DeptId);

            builder.Property(d => d.Name)
            .IsRequired() // NotNull
            .HasMaxLength(50)
            .IsUnicode(false);// varChar (English) not nVArChar

            builder.Property(d => d.YearOfCreation)
            .HasDefaultValue(DateTime.Now.Year);
        }
    }
}
