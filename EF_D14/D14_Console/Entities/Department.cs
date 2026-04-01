using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_Console.Entities
{
    internal class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }// Navigational property
        public Department()
        {
            Employees =new HashSet<Employee>();
        }   
    }
}
