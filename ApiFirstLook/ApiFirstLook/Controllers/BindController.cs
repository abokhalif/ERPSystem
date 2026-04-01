using ApiFirstLook.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstLook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindController : ControllerBase
    {
        //Binding oprimitive type
        // Route data (segment), or Query string 
        //[HttpGet]// default =>Query string 
        //[HttpGet("{id}")]// id =>route ,name =>default Query string 
        [HttpGet("{id:int}/{name:alpha}")]// id ,name=>route data segment
        public IActionResult Get1(int id,string name)
        {

            return Ok();
        }

        

        //Binding Complex type => default for searching complex data in body request,another any oprimitive type look at query string or route data
        //[HttpPost]// search on body for the complex data only
        [HttpPost("{name:alpha}")]// search on body for the complex data and search on request header for primitive(name)
        public IActionResult Add(Employee employee,string name)
        {

            return Ok();
        }
        // if u want send to the server complex datatype by [HttpGet] but it not has abody so u using the attribute
        // to select the header ,query string,route data,[FromServices]=>injected ,[FromForm] send in requesrt body as complex data
        //[HttpGet] //[FromQuery] // assign to each proprty by its name its value//http://localhost:5297/api/Bind?Name=Abdallah%20Saber&Address=Alex&Salary=222&Age=22
        [HttpGet("{Name}/{Address}/{Salary}/{Age}")]//[FromRoute] => if u missing a property will be assign with null // http://localhost:5297/api/Bind/Abdo/mallawi/4444/33
        public IActionResult Get2([FromRoute]Employee employee)
        {

            return Ok();
        }
        // if u want retreive a primitive data type from Body => the body can contain only one thing only as : name or id or employee or list 
        [HttpPost("Post2")]//http://localhost:5297/api/Bind/Post2
        public IActionResult Post2([FromBody] string name/*, [FromBody] int age/error*/)
        {

            return Ok();
        }
    }
}
