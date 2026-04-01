using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeApp.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EmployeetId { get; set; }

        [MaxLength(5)]
        public string EmployeeNumber { get; set; }

        [MaxLength(50)]
        public string EmployeeName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime DOB { get; set; }

        [Display(Name = "Hirirng Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MMM-yyyy}")]
        public DateTime HiringDate { get; set; }
        [Column(TypeName="decimal(12,2)")]
        [Required]
        public decimal GrossSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal NetSalary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Display(Name ="Department")]
        public string DepartmentName { get; set; }


        public virtual Department Department { get; set; }// Navigational property =>Many(Employees) to one (Department)

    }
}
