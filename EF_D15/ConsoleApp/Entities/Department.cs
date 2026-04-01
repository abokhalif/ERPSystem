using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    // EF core support 4 ways to map classes to DB => Must the class(Entity) has Dbset<Class_name> in Context to mapped into the DB
    //    // 1- Convention (Default Action) 
    //    //2- Data Annotation
    //    //3- Fluent API (inside DBContext class,Override on [OnModelCreating] function -> modelBuilder)** // using when not have Source code of entity
    //    // 4- Configuration Classes per Entity 
    internal class Department
    {
        public int DeptId { get; set; } // not follow convension
        public string Name { get; set; }
        public int YearOfCreation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } =new HashSet<Employee>();  // Navigtonal property
    }
}
