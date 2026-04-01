using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp.Entities
{
    // EF core support 4 ways to map classes to DB => Must the class(Entity) has Dbset<Class_name> in Context to mapped into the DB
    // 1- Convention (Default Action)** 
    //2- Data Annotation
    //3- Fluent API (inside DBContext class, OnModelCreating -> modelBuilder)
    // 4- Configuration Classes per Entity 


    /* we have 3 ways to recognize the EF runtime that we have Entity
     *1- using DbSet<>
     *2- using DataAnnotation
     *3- using Fluent API (Not recommended)
     */

    //[Table("Employees")]
    class Employee
    {
        public int ID { get; set; }

        [Required]// Not Null
        [StringLength(50)] // Default nVarChar(UniCode-all Language) but varchar(allow English only)
        public string Name { get; set; }

        [Column(TypeName="money")] 
        public decimal Salary{ get; set; }

        [Range(16,99)]
        public int? Age { get; set; } // Nullable

        [EmailAddress]
        public string Email { get; set; }

        // 1- Full => two NavProp,Fk => add Cascade in migration
        // 2- without FK=> two Navprop=>add Cascade in Mogration
        // 3- without FK and uniNavProp=> one Navprop=>not add any ReferentialAction(Cascade,Restrict,..)
        //
        //[InverseProperty("Department")]//  
         public virtual Department Department { get; set; }// Navigational Property 
        //virtual => to specific the Lazy Loading => when selecting Employee the NavProp not fetch with Employee Prroperties
        
        //[ForeignKey("EmpDept_FK")]
        //public int DepartmentDeptId { get; set; } //FK
    }
}
