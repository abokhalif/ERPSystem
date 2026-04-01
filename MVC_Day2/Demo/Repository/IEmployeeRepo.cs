using Demo.Models;

namespace Demo.Repository
{
    public interface IEmployeeRepo
    {
        Guid guid { get; set; }
        List<Employee> GetAll();

        Employee GetEmployeeByID(int id);

        List<Employee> GetEmployeeByDeptID(int deptID);

        void Insert(Employee employee);

        void Update(int id, Employee NewEmp);
       
        void Delete(int id);
    }
}
