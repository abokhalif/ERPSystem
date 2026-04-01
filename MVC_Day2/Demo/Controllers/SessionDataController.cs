using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    //SessionData/SetSession
    public class SessionDataController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "Ahmed");
            HttpContext.Session.SetInt32("age", 33);
            return Content("Session data saved");
        }
        public IActionResult GetSession()
        {
            string? Name =HttpContext.Session.GetString("name");
            int? Age=HttpContext.Session.GetInt32("age").Value;
            return Content($"name = {Name} , Age= {Age} ");
        }
    }
}
