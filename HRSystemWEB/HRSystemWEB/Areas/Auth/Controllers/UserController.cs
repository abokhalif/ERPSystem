using HRSystemWEB.Areas.Auth.Models;
using HRSystemWEB.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace HRSystemWEB.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginUserDto model)
        {
            var response = await _userService.LoginAsync(model);

            if (response.Success)
            {
                return Ok(response);
            }

            ViewBag.LoginMessage = response.Message;
            return View(model);
        }
    }

}
