using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    //Name confinsion => any className in Controller folder must end with Controller
    public class ProductController : Controller
    {
		// Method => Action
		// cant be private or protected or static or overload(else one case)

		//URL=> Domain//ClassName/ActionName
		#region First Examples
		//public string ShowMsg() => "Hello MVC";
		//public ContentResult ShowContent()
		//{
		//    //Declare object
		//    ContentResult content = new ContentResult();
		//    // set data
		//    content.Content = "ContentResult";
		//    //return the object
		//    return content;
		//}
		//public ContentResult ShowContentv2() => Content("ContentResult");

		//public ViewResult ShowView()
		//{
		//    ViewResult viewResult = new ViewResult();
		//    viewResult.ViewName = "View1";
		//    return viewResult;
		//}
		//public ViewResult ShowViewv2() => View("View1");
		//public JsonResult ShowJson() => new JsonResult(new { ID = 1, Name = "Ahmed" });
		//public JsonResult ShowJsonv2() => Json(new { ID = 1, Name = "Ahmed" });

		//// if u want to return many of typeResult use IActionResult As a return type of the method
		////URL=> Domain//ClassName/ActionName?id=22 & any params..
		////public IActionResult ShowMix(int id)
		////{
		////    if(id%2 == 0) 
		////    {
		////        ContentResult content = new ContentResult();
		////        content.Content = $"{id} is EVen";
		////        return content;
		////    }
		////    return new JsonResult(new { Result=$"{id} is Odd" });
		////}
		//// this function equal to this line
		//public IActionResult ShowMix(int id) => id % 2 == 0 ? Content($"{id} is EVen") : Json(new { Result = $"{id} is Odd" });

		#endregion

		// Product/ Details/1
		ProductSampleData productSample = new ProductSampleData();

		public IActionResult Details(int id)
		{
			// Model 
			Product productModel=productSample.GetById(id);
			// Send View 
			return View("ProductDetails",productModel);// DT=>Product
		}
		public IActionResult Index()
		{
			List<Product> productsListModel = productSample.GetAll();
			return View("ShowAll", productsListModel);// Dt=>List<Product>
		}
	}
}
