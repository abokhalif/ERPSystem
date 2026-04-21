using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if (result.Errors.Any())
            {
                return Unauthorized(result.Errors);
            }
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO refreshRequest)
        {
            var result = await _authService.RefreshTokenAsync(refreshRequest.Token, refreshRequest.RefreshToken);
            if (result.Errors.Any())
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result);
        }
    }
}
