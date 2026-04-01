using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    internal class Student
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }  
        
       // public virtual ICollection<Subject> Subjects { get; set; }=new HashSet<Subject>();
        // Navigational Prop represent Many to many relationShip without any attributes belong to this relation

        //Many to Many with Extea Properies
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new HashSet<StudentSubject>();

    }
}
