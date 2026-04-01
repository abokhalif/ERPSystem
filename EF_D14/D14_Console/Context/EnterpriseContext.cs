using D14_Console.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_Console.Context
{
    internal class EnterpriseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EnterpriseDB;Integrated Security=true;TrustServerCertificate=true;");

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<TrainingCourse> TrainingCourses { get; set; }// it is necessary perform CRUD op. on the class



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        // Specify the store type for the Salary property.
        //        entity.Property(e => e.Salary)
        //              .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed
        //    });
        //}
    }
        





}
