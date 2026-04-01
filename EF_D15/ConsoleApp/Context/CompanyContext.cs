using ConsoleApp.AppConfigurations;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Context
{
    internal class CompanyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data source=.;Initial catalog=CompanyDB;Integrated security=true;TrustServerCertificate=True;");

        // for apply the DataAnnotation validation 
        public override int SaveChanges()
        {
            var Entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Modified || e.State == EntityState.Added /* && e.Entity is Employee // u can add multi conditions */
                           select e.Entity;

            foreach (var Entity in Entities)
            {
                ValidationContext validationContext = new ValidationContext(Entity);
                Validator.ValidateObject(Entity, validationContext,true);// throw VAlidationExecption for each Wrong Property check
            }
            return base.SaveChanges();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*  Fluent API
        //Old Way
            modelBuilder.Entity<Department>().HasKey(D => D.DeptId);

            modelBuilder.Entity<Department>().Property(d => d.Name)
                .IsRequired() // NotNull
                .HasMaxLength(50)
                .IsUnicode(false);// varChar (English) not nVArChar

            modelBuilder.Entity<Department>().Property(d => d.YearOfCreation)
                .HasDefaultValue(DateTime.Now.Year);
            //.HasAnnotation("Required",true) /// to add any annotation if it not found in Fluent API
            */
            /*  modelBuilder.Entity<Department>(EB =>
             {
                EB.HasKey(D => D.DeptId);

                 EB.Property(d => d.Name)
                 .IsRequired() // NotNull
                 .HasMaxLength(50)
                 .IsUnicode(false);// varChar (English) not nVArChar

                 EB.Property(d => d.YearOfCreation)
                 .HasDefaultValue(DateTime.Now.Year);
             });*/

            // Entity Configuraton => Mange FluentApi Code by create config class for Each Entity

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            // u can set and modify on Each Relation btw two Entites by FluentAPI
           // all this done by default by Nav prop def. but u can modify it 
            //modelBuilder.Entity<Employee>()
            //    .HasOne(E => E.Department)
            //    .WithMany(D => D.Employees)// withMany() 
            //    .IsRequired();
            /*.OnDelete(DeleteBehavior.Restrict);*/

            // Many to many with Extra Prperties(indirect Many to many relationship)
            //modelBuilder.Entity<StudentSubject>()
            //    .HasKey(stdsup => new { stdsup.StudentId, stdsup.SubjectId });
            //modelBuilder.Entity<Student>()
            //    .HasMany(std => std.StudentSubjects)
            //    .WithOne(std => std.Student);

            //modelBuilder.Entity<Subject>()
            //    .HasMany(sup => sup.StudentSubjects)
            //    .WithOne(sup => sup.Subject);

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }


    }





}
