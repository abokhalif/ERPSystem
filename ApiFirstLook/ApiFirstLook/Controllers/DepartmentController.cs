using ApiFirstLook.DTO;
using ApiFirstLook.Model;
using ApiFirstLook.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstLook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }
        [HttpGet("Dept/{id:int}")]
        public IActionResult GetDeptWithEmployees(int id)
        {
            //Context context= new Context();
            //Department department = context.Departments.Include(d => d.Employees).FirstOrDefault(e=>e.Id==id);
            Department department = departmentRepo.GetDeptWithEmployees(id);
            if (department is null) return NotFound();
            //Map Model to DTO
            DepartmentEmployeeDTO departmentEmployeeDTO = new DepartmentEmployeeDTO
            {
                Id = department.Id,
                DeptName = department.Name,
                ManagerName = department.ManagerName
            };
            // mapping the list of employees
            foreach (var employee in department.Employees)
            {
                departmentEmployeeDTO.EmpIdName.Add(new EmployeeDTO { Id = employee.Id, Name = employee.Name });
            }
            return Ok(departmentEmployeeDTO);
        }
    }
}
