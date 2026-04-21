using ERP.Domain.Entities.Product;
using ERP.Persistence.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistence.Entities
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//get all config classes that implement IEntityTypeConfiguration<> using reflection instead of adding config for each entity in OnModelCreating()
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VariantOptions>().HasData(
        new VariantOptions { Id = 1, Name = "Color" },
        new VariantOptions { Id = 2, Name = "Size" }
    );

            // 🟢 Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "T-Shirt", BasePrice = 200, CreatedAt = DateTime.Now, IsDeleted = false },
                new Product { Id = 2, Name = "Sneakers", BasePrice = 800, CreatedAt = DateTime.Now, IsDeleted = false }
            );

            // 🟡 Product Variants
            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant { Id = 1, ProductId = 1, Price = 220, Stock = 10, SKU = "TS-RED-M" },
                new ProductVariant { Id = 2, ProductId = 1, Price = 230, Stock = 5, SKU = "TS-BLUE-L" },
                new ProductVariant { Id = 3, ProductId = 2, Price = 850, Stock = 8, SKU = "SN-WHITE-42" }
            );

            // 🟣 Variant Values
            modelBuilder.Entity<VariantValue>().HasData(
                // T-Shirt Red M
                new VariantValue { Id = 1, ProductVariantId = 1, VariantOptionId = 1, Value = "Red" },
                new VariantValue { Id = 2, ProductVariantId = 1, VariantOptionId = 2, Value = "M" },

                // T-Shirt Blue L
                new VariantValue { Id = 3, ProductVariantId = 2, VariantOptionId = 1, Value = "Blue" },
                new VariantValue { Id = 4, ProductVariantId = 2, VariantOptionId = 2, Value = "L" },

                // Sneakers White 42
                new VariantValue { Id = 5, ProductVariantId = 3, VariantOptionId = 1, Value = "White" },
                new VariantValue { Id = 6, ProductVariantId = 3, VariantOptionId = 2, Value = "42" });

            #region Categories Seeding

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic devices and gadgets",
                    DisplayOrder = 1,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothing",
                    Description = "Apparel and fashion items",
                    DisplayOrder = 2,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 3,
                    Name = "Men's Clothing",
                    Description = "Men's apparel",
                    ParentCategoryId = 2,
                    DisplayOrder = 1,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = 4,
                    Name = "Women's Clothing",
                    Description = "Women's apparel",
                    ParentCategoryId = 2,
                    DisplayOrder = 2,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                }
            

            );
            #endregion


        }


        public DbSet<RefreshToken> RefreshTokens { get; set; }
        #region Product Module

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<VariantOptions> VariantOptions { get; set; }
        public DbSet<VariantValue> VariantValues { get; set; }

        #endregion


    }
}
