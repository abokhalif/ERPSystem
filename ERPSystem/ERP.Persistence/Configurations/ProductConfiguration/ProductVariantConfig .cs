using ERP.Domain.Entities.Product;
using ERP.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ERP.Persistence.Configurations.ProductConfiguration
{
    public class ProductVariantConfig : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.SKU)
                .IsRequired()
                .HasMaxLength(100);

            // ✅ Unique SKU
            builder.HasIndex(v => v.SKU)
                .IsUnique();

            builder.Property(v => v.Price)
                .HasColumnType("decimal(18,2)");

            // ✅ Index for performance
            builder.HasIndex(v => v.ProductId);
            builder.HasQueryFilter(v => !v.Product.IsDeleted);


            builder.HasMany(v => v.VariantValues)
                .WithOne(vv => vv.ProductVariant)
                .HasForeignKey(vv => vv.ProductVariantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
