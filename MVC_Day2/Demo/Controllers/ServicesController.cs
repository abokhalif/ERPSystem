using Demo.Filters;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Controllers
{
    //[Authorize] apply on all actions in this controller but if u want an action not belong to the filter use[AllowAnonymous]
    public class ServicesController : Controller
    {
        // Dependency Inversion Principle(DIP)
        IEmployeeRepo EmpRepo;

        //Dependency injection DI =>ask injection
        public ServicesController(IEmployeeRepo emprepo)
        {
            EmpRepo = emprepo;
        }
        // Built in filters
        //[Authorize]                  //exc. before action
        //[ResponseCache(Duration =10)]//exc. after action
        public IActionResult Index()//([FromServices]IEmployeeRepo repo) // inject method 
        {
            ViewBag.ID = EmpRepo.guid;
            return View();
        }

        //[MyFilter]
        public IActionResult TestFilter()
        {
            return Content("Hi My filter");
        }
        [Authorize]
        public IActionResult TestClaims()
        {
            //string Name = User.Identity.Name;
            Claim IdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return Content("claim to user id"+IdClaim.Value);
        }
        }
}
