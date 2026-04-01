using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProj
{
    internal class PersonContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data source=.;Initial Catalog=personDB;Integrated Security=true;TrustServerCertificate=True;");

            

        /*Ex01 => TpH(single Table) with for each concrete class one DbSet
        /// DbSet<> => to inform the EF runtime about tables to map it in DB
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }*/
        /*Ex00
        //in Inheritance the default mapping(without configuration) in migration TpCC => Table per Concrete class(table per child class), to change this => override OnModelCreating() 
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
        // ///in Inheritance the default mapping(without configuration) in migration TpCC => Table per Concrete class(table per child class), to change this => override OnModelCreating() 
        //  ///Ex00=> default mapping with inheritance Tpcc/TpT => table per type
        //    ///modelBuilder.Entity<Teacher>().ToTable("Teacher");
        //    ///modelBuilder.Entity<Student>().ToTable("Students);
        }*/
        /* Ex01
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            // TpH => Table per Hirarchy(one table include all classes of the Hirarchy without duplicate)
            // Add column nvarchar() Discriminator add on each row object type as string
            modelBuilder.Entity<Teacher>().HasBaseType<Person>();
            modelBuilder.Entity<Student>().HasBaseType<Person>();

        }*/

        //Ex02 => TpH(single Table) with only DbSet for the Hirarechy
        public virtual DbSet<Person>People { get; set; }

        public virtual DbSet<Store>Stores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we change the genereted Discremanator by Ef and change its Dt and its values
            modelBuilder.Entity<Person>()
                .HasDiscriminator<bool>(p => p.IsEmployee)// Disc based on existing prop.
                                                          //.HasDiscriminator<bool>("NewDesc")// Disc based on new prop will generate in Migration
                .HasValue<Student>(false)
                .HasValue<Teacher>(true);

            //HasQueryFilter => applied on all Person() queries,if u want to ignore this feture in aspecific query use [.IgnoreQueryFilter]
            // modelBuilder.Entity<Person>().HasQueryFilter(p => !p.IsEmployee); // filter based on the condition of Discriminator 
            // print the Students only apply this condition(!p.IsEmployee = false)

            /* Data Seeding => adding data to the Entity once only on configuring and will added to the Migration
            modelBuilder.Entity<Person>().HasData// if u have a table represent enum(or table contains citys) u can add its facts to the table by data seeding
                (
                new Teacher() { FullName = "Aa", HireDate = DateTime.Now }
                new Student() { FullName = "Ss", HireDate = DateTime.Now }
                );*/

            modelBuilder.Entity<Store>()       // list all attributes from full address as columns in the same table as Store table 
                .OwnsOne(s => s.StoreAddress); // May be OwnsMany If the store has Many(array) addresses

            //modelBuilder.Entity<Store>()
            //    .OwnsOne(s => s.StoreAddress)
            //    .ToTable("FullAddress"); // if u want the owned property represented to a seperate table // Add New Migration
        }
    }
}
 