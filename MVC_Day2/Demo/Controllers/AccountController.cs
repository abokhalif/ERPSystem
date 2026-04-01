using Demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                // Mapping from ViewModel to model
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Address = newUserVM?.Address;
                userModel.PasswordHash = newUserVM.Password;

                // save in db using UserManager=>inject it 
                /*IdentityResult result= await userManager.CreateAsync(userModel);*/// dealing with password as a string
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                //userManager.AddClaimAsync(userModel,new Claim("phone","0112929292"));// add claims on the table of claimuser in data base
                if (result.Succeeded)
                {
                    //Create cookies
                    await signInManager.SignInAsync(userModel, false); // contain Id,name,role// the Authotized action check the cookies content
                    // await userManager.AddToRoleAsync(userModel, "Admin"); // to add any Acount to the role look to AddAdmin Action
                    // List<Claim> claims = new List<Claim>();
                    // claims.Add(new Claim("color", "red"));// add the claims on cookies
                    //await signInManager.SignInWithClaimsAsync(userModel, false, claims);// the Authotized action check the cookies content+the added claims
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("Password", erroritem.Description);

                    }
                }

            }
            return View(newUserVM);
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return View("Register");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel logInViewModel)
        {
            if(ModelState.IsValid)
            {
                //check the username and pass by it in DB
               ApplicationUser user= await userManager.FindByNameAsync(logInViewModel.UserName);
                if (user != null) // if found the user name 
                {
                    bool result=await userManager.CheckPasswordAsync(user,logInViewModel.Password);// check the pass in db by the pass in logInVM
                    if (result==true)
                    {
                        //Create cookies
                        await signInManager.SignInAsync(user, logInViewModel.RememberMe);
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "user name or password wrong");

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                // Mapping from ViewModel to model
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Address = newUserVM?.Address;
                userModel.PasswordHash = newUserVM.Password;

                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, "Admin");
                    //Create cookies
                    await signInManager.SignInAsync(userModel, false); 
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("Password", erroritem.Description);

                    }
                }

            }
            return View(newUserVM);
        }
    }
}
