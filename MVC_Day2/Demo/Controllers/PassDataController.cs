using Demo.Models;
using Humanizer.Localisation;
using Humanizer;
using Microsoft.AspNetCore.Mvc;


namespace Demo.Controllers
{
    //// HTTP is a stateless protocol.Once the server serves any request from the user, it cleans up all the resources used to serve that request
    //, and the state is lost.
    public class PassDataController : Controller
	{
		DataContext context = new DataContext();
        //PassData/ViewTest => URl

        //  There are three ways to pass/store data between the [controllers and views]
        //1-ViewData
        //2-ViewBag=>wrapper around ViewData,Doesn’t require typecasting
        // • ViewBag - viewData can be useful when you want to transfer temporary data (which is not included in model) from the controller to the view ( If redirection occurs, then its value becomes null).
        //3-ViewModel ViewModels area generally a more flexible way to access multiple data sources than using models with ViewBag/ViewData objects
         //– Ex: Employee Data With List of all department

        public IActionResult ViewTest(int id)
		{
			Employee empModel=context.Employees.FirstOrDefault(e => e.Id == id);// Model

			// I need to send More information(data) with Model 
			string Msg = "Hellooo with ITI";
            List<string> Branches = new List<string>
            {
                "SmartVillage",
                "Cairo",
                "Alex",
                "Mynia",
                "Assuit",
                TempData.Peek("Message").ToString(),// call set action[add data to StateMnagement] first then call this action[get]
                $"{HttpContext.Session.GetString("name")} {HttpContext.Session.GetInt32("age").ToString()}" //set the data first
        };
			int Temp = id;
			string color = "Red";
            // 1- ViewData=>Dictionary(string,object)=> the View inherited it from RazorPage()
            //ViewData["Message"] = Msg;
            //ViewData["List"] = Branches;
            //ViewData["Value"] = Temp;
            //ViewData["Color"] = color;

            // 2-ViewBag=>it is Dynamic Datatype and cover the Dictionary of the ViewData, u can set in Action by ViewData or ViewBag and get in View by ViewBag
            // ViewData and ViewBag have the same Dictionary
            //ViewBag.Message = Msg;
            //ViewBag.List = Branches;
            //ViewBag.Value = Temp;
            //ViewBag.Color = color;
            //return View(empModel);

            // 3- ViewModel => Custom Class contain the needed property of model and extra info as properties and send it as a Model to view
            EmployeeWithExtraInfoViewModel empViewModel = new EmployeeWithExtraInfoViewModel();
			empViewModel.Message = Msg;
			empViewModel.Branches = Branches;
			empViewModel.Temp = Temp;
			empViewModel.Color = color;
			empViewModel.Id = empModel.Id;
			empViewModel.Name = empModel.Name;

            return View(empViewModel);

        }
        //

    }
}
