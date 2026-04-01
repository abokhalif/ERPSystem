using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_Console.Entities
{
    /// <summary>
    /// Only 4 ways to map object model (class) to storage model (table
    /// 1- following EF core Convensions => default actions the EF runtime build on its as( class name is solo and table name is [..s] and the PK is clled ID or ClassNameID ...
    /// 2- if object model donot follow EF conventions so using the Data Annotations(in the source code of Entity class)=> some attribute write above the Properties
    /// 3- if the source code not available but the IL is available so using Fluent API by override on [OnModelCreating()] function in Context class
    /// 4- if not available access on context class so using th organization of  the Fluent API by Configuration class => seperate confiqurate class per Entity)
    /// </summary>

    [Table("Courses")]
    internal class TrainingCourse
    {
        [Key]
        public int CourseNumber { get; set; }  // PK

        [Required]// not null
        [MaxLength(50)]// nvar(50)
        public string CourseTitle { get; set; }

        [Column("Duration",TypeName="int")]// change the table name and the data type
        public short CourseDuration { get; set; }

        //[Required]
        //[StringLength(200,MinimumLength=10)]
        //public string CourceURL { get; set; }
        
        /// <summary>
        /// Many to Many Relation Mapping by adding HashSet in both classes and by default the EF runtime will generate the third class(ralation class)
        /// </summary>
        // not need for data annotation because many to many follow EF Convensions
        public virtual ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
    }
}
