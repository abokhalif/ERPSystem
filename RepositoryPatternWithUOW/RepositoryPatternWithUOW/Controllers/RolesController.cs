using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.EF.DTO;

namespace RepositoryPatternWithUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // action to add role to the db [Manager,Admin ,user]
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RoleDTO roleDTO)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = roleDTO.RoleName
                };
                //save in DB
                IdentityResult result= await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return Ok(roleDTO);
                }
                //return BadRequest(result.Errors.First());
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("error", item.Description);
                }
                return BadRequest(ModelState);                
            }
            return BadRequest(roleDTO);

        }

    }
}
