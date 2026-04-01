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
    internal class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                //Order Statuses
                new Status { Id = 1, Name = "Pending" }, //Can be used to with Order, Paymeny, Cancellation, and Refund
                new Status { Id = 2, Name = "Processing" },
                new Status { Id = 3, Name = "Shipped" },
                new Status { Id = 4, Name = "Delivered" },
                new Status { Id = 5, Name = "Canceled" },
                //Refund Status
                new Status { Id = 6, Name = "Completed" },
                new Status { Id = 7, Name = "Failed" },
                //Cancellation Statuses
                new Status { Id = 8, Name = "Approved" },
                new Status { Id = 9, Name = "Rejected" },
                //Payment Status
                new Status { Id = 10, Name = "Refunded" }
                );
        }
    }
}
