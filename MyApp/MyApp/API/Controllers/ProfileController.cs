using BLL.DTOs;
using BLL.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profile = await _userService.GetProfileAsync(userId);
            return Ok(profile);
        }

        [Authorize(Roles = "User")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileDTO profileDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _userService.UpdateProfileAsync(profileDTO, userId);
            if (!success)
            {
                return BadRequest("Profile update failed.");
            }

            return Ok("Profile updated successfully.");
        }

        [AllowAnonymous]
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            return Ok("u in test");
        }
    }
}
