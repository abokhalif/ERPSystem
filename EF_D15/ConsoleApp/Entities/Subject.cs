using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    internal class Subject
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100,MinimumLength =2)]
        public string Title { get; set; }

        //public virtual ICollection<Student> Students { get; set; }= new HashSet<Student>(); 
        // Navigational Prop represent Many to many relationShip without any attributes belong to this relation
       
        //Many to Many with Extea Properies
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new HashSet<StudentSubject>();

    }
}
