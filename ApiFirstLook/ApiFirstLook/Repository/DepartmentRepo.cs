using ApiFirstLook.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstLook.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly Context context;

        public DepartmentRepo(Context dbContext )
        {
            this.context = dbContext;
        }
        public Department GetDeptWithEmployees(int id)
        {
            Department department = context.Departments.Include(d => d.Employees).FirstOrDefault(e => e.Id == id);

            return department;
        }

       
    }
}
