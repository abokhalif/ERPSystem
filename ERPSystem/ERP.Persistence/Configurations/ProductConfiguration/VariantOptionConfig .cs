using ERP.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistence.Configurations.ProductConfiguration
{
    public class VariantOptionConfig : IEntityTypeConfiguration<VariantOptions>
    {
        public void Configure(EntityTypeBuilder<VariantOptions> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);

            // ✅ Optional: prevent duplicate option names
            builder.HasIndex(o => o.Name)
                .IsUnique();
        }
    }
}
