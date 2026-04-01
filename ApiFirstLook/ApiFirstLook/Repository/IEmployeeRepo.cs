using ApiFirstLook.Model;

namespace ApiFirstLook.Repository
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAll();

        Employee GetEmployeeByID(int id);

        Employee GetEmployeeByName(string name);
        Employee GetEmpWithDeptName(int id);

        List<Employee> GetEmployeeByDeptID(int DeptID);
        List<Employee> GetEmployeeByDeptName(string DeptName);

        void Insert(Employee employee);

        void Update(int id, Employee NewEmp);

        void Delete(int id);
    }
}
