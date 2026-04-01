using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
	public class Department
	{
		public int Id { get; set; }

		[Display(Name="Dept name")]
		//[DataType(DataType.Password)]
		public string Name { get; set; }
		public string ManagerName { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
		public Department()
		{
			Employees = new HashSet<Employee>();
		}


	}
}
