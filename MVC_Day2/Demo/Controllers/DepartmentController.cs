using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class DepartmentController : Controller
	{
		// /Department/index
		//DataContext context=new DataContext();

		//DepartmentRepo DeptRepo = new DepartmentRepo(); // without Dependency inversion

		//IDepartmentRepo DeptRepo = new DepartmentRepo(); // Apply Dependency inversion principle but without askContainer

		// using Dependency Injection DP
		IDepartmentRepo DeptRepo;
        // * IoC [Inversion of Control] Service provider
        //1- Register => in Main
        public DepartmentController(IDepartmentRepo IDeptRepo)//2- Constructor inject
        {
			DeptRepo = IDeptRepo;
        }
		//3- create[Resolve] =>during calling the controller and the action in URL
		//4- Destroy(Dispose) the created object
        public IActionResult Index()
		{
			List<Department> ListModel = DeptRepo.GetAll();//context.Departments.ToList();
            //return View("Index",ListModel);//name of Action is the same name of view so we cant write the name of view in return
            return View(ListModel);
		}
		//the rest of ModelBinding p1:=

		[HttpGet]// serve on the request if itis type Anchor tag or <form method="get">
		public IActionResult New ()//Anchor tag open empty form
		{
			return View(new Department());// to not send null ref Department and throw nullRefEx in the Form  
        }

		// if the request type is selected in html as [get or post] it will serve on query string by any not secured data ,so 
		//  we select the type of the requst bt Annotation in controllers
		[HttpPost]// serve only on the request data send by the form
        public IActionResult SaveNew(Department Dept)//submit btn store data in db
        {
			if(Dept.Name!=null)
			{
				DeptRepo.Insert(Dept);
				return RedirectToAction("Index");// after saving the data go to the index(Action) to refresh with new added data
                                                 // can add params as controllerName if the action in another controller or object of the model
            }
            return View("New",Dept);//to return the data of fields if it correct  
        }
    }
}
