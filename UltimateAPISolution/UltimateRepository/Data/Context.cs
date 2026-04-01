using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UltimateCore.Entities;
using UltimateRepository.Data.Config;

namespace UltimateRepository.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new ProductBrandConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//get all config classes that implement IEntityTypeConfiguration<> using reflection instead of adding config for each entity in OnModelCreating()

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories{ get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
    }
}
