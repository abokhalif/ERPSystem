using Demo.Models;

namespace Demo.Repository
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetDepartmentByID(int id);
        List<Department> GetAllWithEmployeesName();
        
        void Insert(Department department);
        void Update(int id, Department NewDept);
        void Delete(int id);
    }
}
