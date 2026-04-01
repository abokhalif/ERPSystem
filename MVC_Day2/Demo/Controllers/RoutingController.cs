using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class RoutingController : Controller
    {
        //{controller=Home}/{action=Index}/{id:int:range(0,100)}/{name:alpha?}// if change the name with id or the datatypes doesnot success
        //Routing/Index/1/Ahmed => success
        //Routing/Index/ali/2  => unsuccess
        //Routing/Index/1 => name=string.Empty => the default of datatype
        public IActionResult Index(int id,string name)
        {
            return Content($"Id={id} ,name={name}");
        }

        [HttpGet("show/{m?}")]//when write Show/msg in url go to [Routing/Show/msg]=> if this wriiten in url will result wrong
        public IActionResult Show(string m)
        {
            return Content($"message = {m}");
        }
    }
}
