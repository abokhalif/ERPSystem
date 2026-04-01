using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class CookieController : Controller
    {//Cookie/SetCookie
        public IActionResult SetCookie()
        {
            CookieOptions options=new CookieOptions ();
            options.Expires = DateTime.Now.AddHours(1);  // set the expiration date of the cookie
            Response.Cookies.Append("name", "Ali",options);
            Response.Cookies.Append("age", 12.ToString());
            return Content("Cookie Saved");
        }
        public IActionResult GetCookie()
        {
            string? Name= Request.Cookies["name"];
            int Age =int.Parse(Request.Cookies["age"]);
            return Content($"name = {Name} , Age= {Age}");
        }
    }
}
