namespace ApiFirstLook.DTO
{
    public class DepartmentEmployeeDTO
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string ManagerName { get; set; }
        public List<EmployeeDTO> EmpIdName { get; set; }=new List<EmployeeDTO>();//must intialize it to avoid adding on null ref

    }
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    }
