using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiFirstLook.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }

        public virtual Department? Department { get; set; }

    }
}
