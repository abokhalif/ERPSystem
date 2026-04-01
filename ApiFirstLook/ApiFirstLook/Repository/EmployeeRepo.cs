using ApiFirstLook.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstLook.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly Context context;
        public EmployeeRepo(Context c)
        {
            context= c;
        }


        public Employee GetEmployeeByID(int id)
        {
            Employee? employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return new Employee();
            return employee;
        }
        public List<Employee> GetAll()
        {
            List<Employee> list = context.Employees.ToList();
            return list;
        }

        public List<Employee> GetEmployeeByDeptID(int deptID)
        {
            return context.Employees.Where(d=>d.Dept_Id==deptID).ToList();
        }
        public Employee GetEmployeeByName(string name)
        {
            Employee? employee = context.Employees.FirstOrDefault(e => e.Name == name);
            if (employee is null)
                return new Employee();
            return employee;

        }
        public Employee GetEmpWithDeptName(int id)
        {
            Employee employee = context.Employees.Include(d => d.Department).FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public List<Employee> GetEmployeeByDeptName(string DeptName)
        {
            return context.Employees.Where(e => e.Name == DeptName).ToList();
        }

       

        public void Insert(Employee employee)
        {
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }

        public void Update(int id, Employee NewEmp)
        {
            Employee oldEmployee=GetEmployeeByID(id);
            oldEmployee.Name=NewEmp.Name;
            oldEmployee.Salary=NewEmp.Salary;
            oldEmployee.Address=NewEmp.Address;
            oldEmployee.Dept_Id=NewEmp.Dept_Id;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Employee employee = GetEmployeeByID(id);
            context.Remove(employee);
            context.SaveChanges();
        }
    }
}
