using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
	public class Employee
	{
		public int Id { get; set; }
		[Required]
		[MinLength(1)]
		[MaxLength(20)]
        [UniqueName(Message = "the Name is found please try again")]//Custom Validation 1[server Side Validation]
		public string? Name { get; set; }
		//[RegularExpression(@"[0-9]{4}")]
		//[Range(1000,10000,ErrorMessage ="the salary must btw 1000 and 10000")]
        // Remote() server Side Validation but can run as client Side Validation if the page access Ajax[but goes to server every text change)
		// u can add additional properties and make constraints at it in the action
        [Remote("CheckSalary","Employee",ErrorMessage ="check the number")]// create CheckSalary Action take the prop(the same Name) as param in the EmployeeController and return Json(false/true)
		public int Salary { get; set; }

		[Required]
		[RegularExpression("Alex|Cairo|Minya|Assuit|Giza",ErrorMessage ="Not in selected Addresses")]
		public string? Address {get;set;}
		[RegularExpression(@"[a-z]+\.(jpg|png)", ErrorMessage ="not image format")]
		public string? Image { get; set; }

		[ForeignKey("Depart")]
		[Display(Name="Department")]
		public int DeptId { get; set; }
		public virtual Department? Depart { get; set; }
			 


	}
}
