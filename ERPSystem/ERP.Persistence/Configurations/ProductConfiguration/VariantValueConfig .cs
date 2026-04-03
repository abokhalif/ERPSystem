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
    public class VariantValueConfig : IEntityTypeConfiguration<VariantValue>
    {
        public void Configure(EntityTypeBuilder<VariantValue> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Value)
                .IsRequired()
                .HasMaxLength(100);

            // ✅ Prevent duplicate option per variant
            builder.HasIndex(v => new { v.ProductVariantId, v.VariantOptionId })
                .IsUnique();

            // ✅ Index for performance
            builder.HasIndex(v => v.ProductVariantId);

            builder.HasOne(v => v.Option)
                .WithMany()
                .HasForeignKey(v => v.VariantOptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
