using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UltimateAPI.Errors;

namespace UltimateAPI.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorsController :ControllerBase
    {
        public ActionResult Error(int code)
        {
            return NotFound(ApiResponse<object>.Fail(statusCode: 404));
        }
    }
}
