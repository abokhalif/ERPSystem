using ApiFirstLook.DTO;
using ApiFirstLook.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;

namespace ApiFirstLook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        //Registration
        [HttpPost("register")]
        public async Task<IActionResult> Registeration(DTO.RegisterUserDTO userDTO)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName= userDTO.UserName;
                user.Email= userDTO.Email;
                // user.PasswordHash = userDTO.Password;
                IdentityResult result =await userManager.CreateAsync(user, userDTO.Password);
                if(result.Succeeded)
                {
                    return Ok("Done,the Account Added");
                }
                return BadRequest(result.Errors.First());
            }
            return BadRequest(ModelState);
        }
        //LogIn
        [HttpPost]
        public async Task< IActionResult> Login(LoginUserDTO userDTO)
        {
            if (ModelState.IsValid) 
            {
                //1-check userName
                ApplicationUser user=await userManager.FindByNameAsync(userDTO.UserName);
                if (user != null)
                {
                    //2-check password
                    bool found=await userManager.CheckPasswordAsync(user,userDTO.Password);
                    if (found)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, userDTO.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        // role
                        var roles = await userManager.GetRolesAsync(user);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                            
                        }

                        SecurityKey securityKey= new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                        SigningCredentials signingCredentials=new SigningCredentials (securityKey, SecurityAlgorithms.HmacSha256);


                        //3-create token
                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: configuration["JWT:ValidIssuer"],//web api url [provider],added in appsettingjson
                            audience: configuration["JWT:ValidAudiance"],// consumer api [angular]
                            claims:claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signingCredentials

                        );
                        return Ok(new
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        }) ;
                    }
                }
                return Unauthorized();

            }
            return Unauthorized();


        }
    }
}
