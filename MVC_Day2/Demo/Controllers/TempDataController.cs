using Microsoft.AspNetCore.Mvc;
//State management
//• The state can be stored using several approaches: 
//– Cookies 
//– Session State 
//– TempData
//– Query String 
//– Hidden fields • Etc
namespace Demo.Controllers
{
    // TempData => Used to pass data from the current request to the next request [share data between controllers actions(any next request in any controller )]
    //By default, the TempData saves its content to the session state[Cookies=>one per client,per webApp,per browser].
    // still saved in cookie until session timeout or normal read from TempData
    //• It requires typecasting
    public class TempDataController : Controller
    {
        //TempData/SetTempData
        // DataContext context = new DataContext();


        public IActionResult SetTempData()
        {
            //set(write)
            TempData["Message"] = "Hello Message";

            return Content("setting Data to TempData");
        }
        public IActionResult Get1TempData()
        {
            string message = "Empty Message Get1TempData";
            if (TempData.ContainsKey("Message"))
            {
                //get(read)
                message = TempData["Message"].ToString();// normal reading => after it the tempdata["key"] is deleted from cookies , 
                //if u need to save the data inside Tempdata using:=
                // TempData.Keep("Message");// after normal reading keeping the data until the next request
                //message=TempData.Peek("Message").ToString();// or read and not remove the data
                //TempData.Remove("Message");
            }
            return Content ("Reading from Get1TempData " + message);
        }
        public IActionResult Get2TempData()
        {
            //it dropped when readed and then throw Ex so
            string message = "Empty Message Get2TempData";
            if (TempData.ContainsKey("Message"))
            {
                message = TempData["Message"].ToString();
            };
            return Content("Reading from Get2TempData " + message);
        }
    }
}
