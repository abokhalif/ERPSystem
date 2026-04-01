using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        HRDataBaseContext context=new HRDataBaseContext ();
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("DepartmentName");
            if(ModelState.IsValid) { 
               context.Employees.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = context.Departments.ToList();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e=>e.EmployeetId==id);
            ViewBag.Departments = context.Departments.ToList();
            return View("Create",employee);
        }

    }
}
