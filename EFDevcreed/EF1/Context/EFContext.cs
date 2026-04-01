using EF1.Configurations;
using EF1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF1.Context
{
    internal class EFContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DbDevCreed;integrated Security=true;TrustServerCertificate=True; ");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>().ToTable("Posts");// to map the class to table in DB
            //modelBuilder.Entity<Blog>().ToTable("Blogs");

            //modelBuilder.Entity<Post>();// to map the class to table in DB
            //modelBuilder.Entity<Blog>();

            // // to exclude a table from migrations[not added to the updating database but still in DB] =>
            // 1- [NotMapped] above table or Nav.prop 
            //modelBuilder.Entity<Post>().Ignore(p=>p.Content);// to exclude an property frm migration
            //modelBuilder.Ignore<Post>();// 2-to exclude a table from migrations
            // modelBuilder.Entity<Post>().ToTable("Posts", p => p.ExcludeFromMigrations());// 3- to exclude a table from migrations

            //modelBuilder.Entity<Post>().ToView("Posts"); // if the return object from View Mapping to class if not mapping to any class create [keyLess] class to map a view or query or S_P or function

            //*** Default Value
            //modelBuilder.Entity<Post>().Property(p => p.Content).HasDefaultValue("EmptyContent");//Default Value=> value
            //modelBuilder.Entity<Post>().Property(p => p.CreateOn).HasDefaultValueSql("GETDate()");//  Default Value=> function , query ,.. return the same datatype of the property

            //*** Computed Columns => virtual columns their data computed from another columns and permit midification ,momently updated from other columns
            modelBuilder.Entity<Publisher>().Property(p => p.DisplayName).HasComputedColumnSql("[FName] +' '+ [LName]");

            // apply this filter on every query on publisher entity
           // modelBuilder.Entity<Publisher>().HasQueryFilter(p => p.Id > 10);
            //***To can add value to PK
           // modelBuilder.Entity<Category>().Property(p => p.Id).ValueGeneratedOnAdd();

            BlogConfig blogConfig = new BlogConfig();
            blogConfig.Configure(modelBuilder.Entity<Blog>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
