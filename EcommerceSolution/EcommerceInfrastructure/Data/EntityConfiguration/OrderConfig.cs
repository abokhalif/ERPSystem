using EcommerceCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceInfrastructure.Data.EntityConfiguration
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Order -> BillingAddress 
            builder.HasOne(o => o.BillingAddress)
                   .WithMany()
                   .HasForeignKey(o => o.BillingAddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Order -> ShippingAddress 
            builder.HasOne(o => o.ShippingAddress)
                   .WithMany()
                   .HasForeignKey(o => o.ShippingAddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Order -> Cancellation 
            builder.HasOne(o => o.Cancellation)
                   .WithOne(c => c.Order)
                   .HasForeignKey<Cancellation>(c => c.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}