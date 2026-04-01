using HRSystemWEB.Areas.Auth.Models;
using HRSystemWEB.Services.Employee;
using Microsoft.AspNetCore.Mvc;

namespace HRSystemWEB.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var response = await _employeeService.GetAllDataAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var response = await _employeeService.GetAllDataAsync();
            return Ok(response);
        }
    }
}
