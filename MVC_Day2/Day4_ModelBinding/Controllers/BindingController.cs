//using Demo.Models;
using Day4_ModelBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day4_ModelBinding.Controllers
{
    public class BindingController : Controller
    {
        //Model Binding => send data from view(client) to controller(server) ,Map Action Parameters with request data[Form data -> Post->in request body(Hidden),Get->Query string , Route data]
        
        //Model Binding types : 
        // 1- Bind Primitive Type
        // /Binding/TestPrimitiveType/1?name="" =>Routing data
        // /Binding/TestPrimitiveType?id=3&name="" => Query string(Get)
        public IActionResult TestPrimitiveType(int id,string name)
        {
            //if not data sended in the request the parameters will store the default values
            return Content($"Id={id} , Name={name}");
        }

        // /Binding/TestCollectionType/1?name="cc"&colors=red&colors=blue 
        // /Binding/TestCollectionType/1?name="cc"&colors[1]=red&colors[0]=blue 
        public IActionResult TestCollectionType(int id, string name, string[] Colors)
        {
            // u can select the index of the collection or let it default
            return Content($"Id={id} , Name={name},color[0]={Colors[0]}");
        }

        // /Binding/TestDictionary?Emps[ali]=100&Emps[jack]=101&Emps[John]=105
        public IActionResult TestDictionary(Dictionary<string,int> Emps)
        {
            return Content($"Id ali={Emps["ali"]} , Id jack={Emps["jack"]} ");

        }
        // Custom Types
        // /Binding/TestCustomType?Id=1&Name="mina"&ManagerName="jack"
        public IActionResult TestCustomType(Dapartment Dept)
        {
            // u select some of parameters and the rest will have default values
            return Content($" Id={Dept.Id}  Name = {Dept.Name} ManagerName= {Dept.ManagerName}");

        }
        // /Binding/TestCustomType?Id=1&Name="mina"&ManagerName="jack"
        public IActionResult TestCustomType2(
            [Bind(include:"Id,Name")]Dapartment Dept)// to select the requried params from the URL,the other params will have the default values
        {
            // u select some of parameters and the rest will have default values
            return Content($" Id={Dept.Id}  Name = {Dept.Name}");

        }

    }
}
