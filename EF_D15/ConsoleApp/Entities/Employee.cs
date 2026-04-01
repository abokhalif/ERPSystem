//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;


//namespace ConsoleApp.Entities
//{
//    // EF core support 4 ways to map classes to DB => Must the class(Entity) has Dbset<Class_name> in Context to mapped into the DB
//    // 1- Convention (Default Action)** 
//    //2- Data Annotation
//    //3- Fluent API (inside DBContext class, OnModelCreating -> modelBuilder)
//    // 4- Configuration Classes per Entity 
//    class Employee
//    {
//        public int ID { get; set; }
//        public string Name { get; set; }
//        public decimal Salary{ get; set; }
//        public int? Age { get; set; }

//    }
//}
