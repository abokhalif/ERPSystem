using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        //DataContext context = new DataContext();
        //EmployeeRepo EmpRepo = new EmployeeRepo(); // without Dependency inversion

        //IEmployeeRepo EmpRepo = new EmployeeRepo(); // Apply Dependency inversion principle but without IOCContainer
        //IDepartmentRepo DeptRepo =new DepartmentRepo (); // Apply Dependency inversion principle but without IOCContainer

        // Dependency Injection DP => using in 
        // 1- Constructor parameter => the default in .net core
        //2- Preperty
        // 3- in Method
        IEmployeeRepo EmpRepo ;
        IDepartmentRepo DeptRepo ;
        public EmployeeController(IEmployeeRepo IEmpRepo, IDepartmentRepo IDeptRepo)
        {
            EmpRepo=IEmpRepo;
            DeptRepo=IDeptRepo;
        }

        


        public IActionResult CheckSalary(int Salary)
        {
            if(Salary > 1000&&Salary<10000)
            {
                return Json(true);
            }

            return Json(false);
        }
        public IActionResult New()
        {
            ViewData["deptList"] = EmpRepo.GetAll();// to load the name of Departments in dropdown list
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]// to validate the server that send the action and view to prevent the Hacker attack
        public IActionResult SaveNew(Employee NewEmp)
        {
            //modelState=> a dictionary that contain result of validate of each property
            if (ModelState.IsValid==true)// server side Validation[Data Annotation]
            {
                try
                {
                    EmpRepo.Insert(NewEmp);
                    return RedirectToAction("Index");
                }
                catch(Exception Ex)
                {
                    //if u need to show the error to the view add the Key and the error message to the ModelState
                    ModelState.AddModelError(string.Empty,"Please Select Department" /*Ex.Message*/);
                    //if the Key is the Name of property then it view in the span of this property
                    //if the Key is new name view it in new div
                }

            }
            ViewData["deptList"] = EmpRepo.GetAll();// to load the name of Departments in dropdown list 
            return View("New", NewEmp);
        }

        [Authorize]// check if the user has cookies
        public IActionResult Index()
        {
            return View(EmpRepo.GetAll());
        }
        //Anchor tag goto Edit View
        public IActionResult Edit(int id)
        {
            Employee? employee= EmpRepo.GetEmployeeByID(id);
            ViewData["deptList"] = DeptRepo.GetAll();//send extra data to the view with the model

            return View(employee);
        }
        // submit save edited data and goto Index or if not correct data reload Edit again
        [HttpPost]
        public IActionResult SaveEdit(int id,Employee NewEmp)
        {

            //NodelState=> a dictionary that contain result of validate of each property
            if(ModelState.IsValid)// server side Validation[Data Annotation]
            {
                EmpRepo.Update(id, NewEmp);

                return RedirectToAction("Index");
                
            }
            ViewData["deptList"]=DeptRepo.GetAll();// to load the name of Departments in dropdown list 
            return View("Edit", NewEmp);
        }
    }
}
