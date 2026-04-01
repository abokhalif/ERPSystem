/* Ex01 => Table per Hirarechy TpH with for each concrete class one DbSet
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleProj
//{
//    public abstract class Person
//    {
//        public int Id { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string FullName { get; set; }
//    }
//    public class Teacher : Person 
//    { 
//        public DateTime HireDate { get; set; }
//    }
//    public class Student : Person
//    {
//        public DateTime HireDate { get; set; }
//    }

//}*/

//Ex02 => Table per Hirarechy TpH with only one DbSet per the all Hirerichay

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProj
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        public bool IsEmployee { get; protected set; }
    }
    public class Teacher : Person
    {
        public Teacher()
        {
            IsEmployee = true;
        }
        public DateTime HireDate { get; set; }
    }
    public class Student : Person
    {
        public Student()
        {
            IsEmployee = false;
        }
        public DateTime HireDate { get; set; }
    }

}

