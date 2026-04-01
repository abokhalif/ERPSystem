using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public JsonResult JsonStudents() // it is a controller it return a JSON document , you can use the base class ActionResult
        {
            List<Models.Student> l1 = new List<Models.Student>()
            {
                new Models.Student() { StudentName = "Ahmed", StudentId = 123, Department = "CS", StudentAge = 20 },
                new Models.Student() { StudentName = "Amr", StudentId = 124, Department = "IT", StudentAge = 20 },
                new Models.Student() { StudentName = "Ali", StudentId = 125, Department = "IS", StudentAge = 21 },
                new Models.Student() { StudentName = "mohammed", StudentId = 126, Department = "CS", StudentAge = 20 },

            };
            return Json(l1,JsonRequestBehavior.AllowGet);// Json(object data,the behavior of the request is AlloGet or DenyGet
                         
        }
        public ContentResult IndexContent()// controller use to write a html code (ActionResult) the base class
        {
            return Content("<h1 style= color:White background: black>Welcome To my Website </h1>");
        }
        public FilePathResult IndexFile()
        {
            //return File("~/Content/ASP.NET._Software_Engineering.pdf", "Lab7.pdf"); // to show the file
            return File(Server.MapPath("~/Content/ASP.NET._Software_Engineering.pdf"), "pdf", "Lab7.pdf");// to direct download to the device 
        }
        public RedirectToRouteResult IndexRedirect()   // (ActionResult) the base class meaning that you can use the base class alter rhese classes
        {
            return RedirectToAction("Welcome"); // show the Welcome controller
             
        }

    }
}