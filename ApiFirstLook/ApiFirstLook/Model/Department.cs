using System.Text.Json.Serialization;

namespace ApiFirstLook.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        //[JsonIgnore] // not recommended solution for Cicle refrence looping exception
        public virtual ICollection<Employee>? Employees { get; set; }


    }
}
