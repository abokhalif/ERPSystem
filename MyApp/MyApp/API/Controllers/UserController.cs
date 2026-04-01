
using BLL.DTOs;
using BLL.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var result = await _userService.RegisterAsync(registerDTO);
            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _userService.LoginAsync(loginDTO);
            if (result.Errors.Any())
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO refreshRequest)
        {
            var result = await _userService.RefreshTokenAsync(refreshRequest.Token, refreshRequest.RefreshToken);
            if (result.Errors.Any())
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result);
        }

    }
}
