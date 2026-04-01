using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Filters
{
    public class MyFilter : Attribute, IActionFilter// ecexuted OnActionExecuting or OnActionExecuted before getout the response
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
        }

       
    }
    public class MyFilter2 : Attribute, IAuthorizationFilter// ecexuting before Action execution 
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class MyFilter3 : Attribute, IResultFilter// ecexuting after Action execution 
    {
       

        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
