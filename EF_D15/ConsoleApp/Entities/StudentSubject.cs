using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    /// <summary>
    /// Many to Many Relation with Extra Properties
    /// </summary>
    internal class StudentSubject
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public virtual Student Student { get; set; }    
        public virtual Subject Subject { get; set; }

        public int Grade { get; set; }  


    }
}
