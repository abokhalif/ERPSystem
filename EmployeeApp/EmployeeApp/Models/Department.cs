using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("Department",Schema ="dbo")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Department ID")]
        public int DepartmentId { get; set; }

        [Required]
        [Column(TypeName="nvarchar(50)")]
        [Display(Name = "Department Name")]
        public string? DepartmentName { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        [Display(Name = "Department Abbreviation")]
        public string? DepartmentAbb { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }// Navigational property
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
