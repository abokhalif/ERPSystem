using Demo.Models;

namespace Demo.Repository
{
    public class EmployeeRepo:IEmployeeRepo
    {

        // DataContext context = new DataContext();
        DataContext context;//ask
        public EmployeeRepo(DataContext db)
        {
            context = db;
        }
        public Guid guid { get; set; }
        public EmployeeRepo()
        {
            guid = Guid.NewGuid();//create uniqe id for each instance of the object to clarify the methods of add container
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = context.Employees.ToList();
            return employees;
        }
        public Employee GetEmployeeByID(int id)
        {
            Employee? employee = context.Employees.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        
        public List<Employee> GetEmployeeByDeptID(int deptID)
        {
            return context.Employees.Where(e => e.DeptId == deptID).ToList();
        }
        public void Insert(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }
        public void Update(int id, Employee NewEmp)
        {
            Employee OldEmp = GetEmployeeByID(id);

            OldEmp.Name = NewEmp.Name;
            OldEmp.Salary = NewEmp.Salary;
            OldEmp.Address = NewEmp.Address;
            OldEmp.DeptId = NewEmp.DeptId;
            OldEmp.Image = NewEmp.Image;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Employee OldEmp = GetEmployeeByID(id);
            context.Employees.Remove(OldEmp);
            context.SaveChanges();


        }
    }
}
