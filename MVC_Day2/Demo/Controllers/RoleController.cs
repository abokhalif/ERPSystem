using Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityRole roleModel=new IdentityRole ();
                roleModel.Name = roleViewModel.Role;
                //save db
                IdentityResult result= await roleManager.CreateAsync(roleModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                
                }
            }
            return View();
        }
    }
}
