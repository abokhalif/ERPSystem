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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeController(IEmployeeRepo employee)
        {
            this.employeeRepo = employee;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<Employee> list = employeeRepo.GetAll();
            return Ok(list);
        }

        // i want to send the parameter with url????????
        //[Route("/api/[controller]/{id}")]// replace on the controller url  [Route("api/[controller]")]
        //[Route("{id}")]        /// Concatenate with controller url
        [HttpGet("{id:int}", Name = "GetEmployeeByID")]   // the name must be unique cause it added in adictionary 
        public IActionResult GetEmployeeByID([FromRoute] int id) // search on the params in the url(query string) for
                                                                 // the primitive dt but in case the complex [FromBody] search on the body of the request
        {
            Employee employee = employeeRepo.GetEmployeeByID(id);
            return Ok(employee);
        }
        [HttpGet("{name:alpha}")]        // without  [Route("{id}")] 
        public IActionResult GetEmployeeByName(string name)
        {
            Employee employee = employeeRepo.GetEmployeeByName(name);
            return Ok(employee);
        }

        // in promitive and non primitive data type in parameters ,the non_prim sended in request body(default) but u must 
        //determine the the prim dt will sended as query string or as a segment
        [HttpPut("{id:int}")]        // without  [Route("{id}")] 
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
               employeeRepo.Update(id,employee);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepo.Insert(employee);  
                //return Created("", new { employee.Id });
                //return Created("http://localhost:5297/api/Employee/"+ employee.Id,  employee);//(request header ,request body) // static url is bad
                string url = Url.Link("GetEmployeeByID", new { id = employee.Id }); // Dynamic
                return Created(url, employee); // (URL in header ,employee in bidy request)
            }
            return BadRequest(ModelState);
        }
        //***[HttpDelete] //http://localhost:5297/api/Employee?id=6 => add as query string
        [HttpDelete("{id}")]//http://localhost:5297/api/Employee/3 => add as a segment 
        public IActionResult RemoveEmployee(int id)
        {
            try
            {
               employeeRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("Emp/{id:int}")]// /api/dept/1
        public IActionResult GetEmpWithDeptName(int id)
        {
            //1-
            //var employee = context.Employees.Include(d=>d.Department).FirstOrDefault(e=>e.Id==id);// with [JsonIgnore]
            //2-
            //var employee = context.Employees.Where(e => e.Id == id).Select(e=>new { e.Id,e.Name,e.Department}); // another solution but not strong type its dynamic[IQuerable]
            //3-
            //the latest solution is DTO (data transfer object) => create a class that contain the properties will be shown and assign to it and return it[viewModel]

            // Employee employee = context.Employees.Include(d => d.Department).FirstOrDefault(e => e.Id == id);
            Employee employee = employeeRepo.GetEmpWithDeptName(id);
            if (employee is null) return NotFound();
            EmployeeDepartmentDTO employeeDepartmentDTO = new EmployeeDepartmentDTO
            {
                EmpId = employee.Id,
                EmpName = employee.Name,
                DeptName = employee.Department.Name,
                //another way to assign object in object
                //DepartmentEmployee =new DepartmentEmployeeDTO
                //{
                //    DeptName= employee.Department.Name
                //}
            };
            // if u want to make a list of Employees , look at DepartmentController class
            return Ok(employeeDepartmentDTO);
        }
    }
}
