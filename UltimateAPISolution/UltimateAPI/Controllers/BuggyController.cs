using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltimateAPI.Dtos;
using UltimateAPI.Errors;
using UltimateRepository.Data;

namespace UltimateAPI.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly Context context;

        public BuggyController(Context context)
        {
            this.context = context;
        }
        [HttpGet("NotFound")]
        public ActionResult NotFoundRequest()
        {
            return BadRequest(ApiResponse<object>.Fail(statusCode:400));
        }
        [HttpGet("ServerError")]
        public ActionResult ServerError()
        {
            var product = context.Products.Find(100);
            var productToString = product.ToString();// will throw NullRefrenceException
            return Ok(productToString);
        }
        [HttpGet("GetBadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }
        [HttpPut("ValidationError")]
        public ActionResult ValidationError([FromBody]TestDto test)// send name with more than max length that determined in validation attribute[data annotation]
        {
            // if invalid validation fired the response will send 400 and message with array of errors in attribute by configure in services
            return Ok();
        }
        [HttpGet("UnAuthorized")]
        public ActionResult UnAuthorizedError()// send id as string for the validation
        {
            return BadRequest(ApiResponse<object>.Fail( statusCode: 401));

        }
    }
}
