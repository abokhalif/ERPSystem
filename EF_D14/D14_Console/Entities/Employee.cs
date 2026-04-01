using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_Console.Entities
{/// <summary>
/// POCO classes=>
/// Plain Old CLR Objects (POCO): POCO classes are simple classes with properties that represent database entities.
/// They do not inherit from any base class provided by EF Core, nor do they require any specific attributes or annotations.
/// This allows you to create your domain classes in a clean and object-oriented way.
/// can run in CLR without any addational libraries (pure class)
/// </summary>
// in EF runtime the EFConvetion applied (PK->called "ID or ClassNameID" , NavProp using as FK u can write it in one class or the both classes of the relation
    internal class Employee
    {
        public int ID { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public decimal Salary { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; } 
        public int DepartmentID { get; set; }//As a Foreign key but u can replace it with Navigational property 
        public virtual Department Department { get; set; }// Navigational property =>Many(Employees) to one (Department)
        // many to many
        public virtual ICollection<TrainingCourse> TrainingCourses { get; set; } = new HashSet<TrainingCourse>();// the third class wiht composite PK (EmpId,courseNum)

    }
}
