using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuredController : ControllerBase
    {
        [HttpGet("getData")]
        [Authorize(Roles = "User")]

        public IActionResult GetData()
        {
            return Ok("Hello from secured controller");
        }

    }
}
