using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public class DepartmentRepo:IDepartmentRepo
    {
        //DataContext context = new DataContext();
        DataContext context;//ask
        public DepartmentRepo(DataContext db)
        {
            context = db;
        }
        public List<Department> GetAll()
        {
            List<Department> departments = context.Departments.ToList();
            return departments;
        }
        public Department GetDepartmentByID(int id)
        {
            Department? department = context.Departments.FirstOrDefault(e => e.Id == id);
            return department;
        }
        public List<Department> GetAllWithEmployeesName()
        {
            return context.Departments.Include(d=>d.Employees).ToList();
        }
        public void Insert(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }
        public void Update(int id, Department NewDept)
        {
            Department OldDept = GetDepartmentByID(id);

            OldDept.Name = NewDept.Name;
            OldDept.ManagerName = NewDept.ManagerName;
            
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Department OldDept = GetDepartmentByID(id);
            context.Departments.Remove(OldDept);
            context.SaveChanges();


        }
    }
}
