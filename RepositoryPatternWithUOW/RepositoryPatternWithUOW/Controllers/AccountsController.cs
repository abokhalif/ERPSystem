using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryPatternWithUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]// make the all actions in this controller authorized
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;//manage account of users => create ,delete update,..
        private readonly SignInManager<ApplicationUser> signInManager;//mange cookies
        private readonly IConfiguration configuration;

        public AccountsController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        [HttpPost("LogOut")]
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return Ok(new {message="signout complete"});

        }
        [AllowAnonymous]// make this action not require authorization even the controller is Aothorize
        [HttpPost("LogIn")]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInDTO logInDTO)
        {
            #region Log In Using Identity and cookies
            /*

            if (ModelState.IsValid)
            {
                //check if the user name found or not and store the user object to check the password if it not null
                ApplicationUser user = await userManager.FindByNameAsync(logInDTO.UserName);
                if (user != null)
                {
                    bool found=await userManager.CheckPasswordAsync(user, logInDTO.Password);
                    if(found)
                    {
                        //create cookies with out claims             // Remember to determine the president=> if the cookie still after the browser closing
                        await signInManager.SignInAsync(user,logInDTO.RememberMe);
                        return Ok();
                    }
                    return BadRequest(new { K="Invalid password" });

                }
                return BadRequest(new { K2 = "UserName Not found" });
            }
            return BadRequest(new { K3 = "Invalid Account" });
            */
            #endregion
            #region Log In Using jwt and token must reconfigure the default check of useAuthentication
            if (ModelState.IsValid)
               {
                   ApplicationUser user = await userManager.FindByNameAsync(logInDTO.UserName);
                   if (user != null)
                   {
                       bool found = await userManager.CheckPasswordAsync(user, logInDTO.Password);
                       var claims = new List<Claim>
                       {
                           new Claim(ClaimTypes.Name, user.UserName),
                           new Claim(ClaimTypes.NameIdentifier, user.Id),
                           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                       };
                       var roles = await userManager.GetRolesAsync(user);
                       foreach (var role in roles)
                       {
                           claims.Add(new Claim(ClaimTypes.Role, role));
                       }

                       if (found)
                       {
                           //create token
                           JwtSecurityToken myToken = new JwtSecurityToken(
                               issuer: configuration["JWT:ValidIssuer"],//url web api(provider)
                               audience: configuration["JWT:ValidAudiance"],//url of front(consumer)
                               claims:claims,
                               expires:DateTime.Now.AddMinutes(12),
                               signingCredentials:new SigningCredentials(new SymmetricSecurityKey(
                                   Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                                   SecurityAlgorithms.HmacSha256)

                               );
                           await signInManager.SignInAsync(user, logInDTO.RememberMe);
                           return Ok(new
                           {
                               token = new JwtSecurityTokenHandler().WriteToken(myToken),
                               expiration=myToken.ValidTo
                           } ); 
                       }
                       return Unauthorized(new { K = "Invalid password" });

                   }
                   return Unauthorized(new { K2 = "UserName Not found" });
               }
               return BadRequest(new { K3 = "Invalid Account" });
               
            #endregion
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if(ModelState.IsValid)
            {
                //Mapping from RegisterDTO to ApplicaationUser
                ApplicationUser user = new ApplicationUser
                {
                    UserName = registerDTO.UserName,
                    PasswordHash = registerDTO.Password,
                    Address = registerDTO.Address
                };
                // userManager perform check its own validation in username and password and return IdentityUser[succeeded,failed,ErrorList]
                IdentityResult result = await userManager.CreateAsync(user,registerDTO.Password);//to make all password validation

                if (result.Succeeded)
                {
                   IdentityResult result1=
                   await userManager.AddToRoleAsync(user, "User");///to add arole after registeration and before sign in
                    if (result1.Succeeded)
                    {
                        //create cookie=>stores in cookies of the session in the browser
                        //1
                        // await signInManager.SignInAsync(user, false);// to add the id ,name ,role of the Application user 
                        // if u need to add extra info use [custom claims]
                        var claims = new List<Claim>();
                        claims.Add(new Claim("color", "red"));
                        //2
                        await signInManager.SignInWithClaimsAsync(user, true, claims);
                        return Ok(user);
                    }
                    return BadRequest(result1.Errors);
                }
                else
                {
                    //return BadRequest(result.Errors.First());
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                    return BadRequest(ModelState);
                }
                
            }

            return BadRequest(registerDTO);
            
        }

        [HttpGet("GetIdFromClaims")]
        [Authorize]
        public IActionResult GetIdFromClaims()
        {
            string Name=User.Identity.Name;
            // to deremine wich type of the claims are u want(c=>c.Type=="Color")=>added claims
            //Claim claim=User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier);//Guid
            Claim claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            return Ok(claim.Value);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = registerDTO.UserName,
                    PasswordHash = registerDTO.Password,
                    Address = registerDTO.Address
                };
                // userManager perform check its own validation in username and password and return IdentityUser[succeeded,failed,ErrorList]
                IdentityResult result = await userManager.CreateAsync(user, registerDTO.Password);//to make all password validation

                if (result.Succeeded)
                {
                    //IdentityResult result1=
                    await userManager.AddToRoleAsync(user, "Admin");///to add arole after registeration and before sign in
                    //not to need add cookies
                    // await signInManager.SignInAsync(user, false);// to add the id ,name ,role of the Application user 
                    //var claims = new List<Claim>();
                    //claims.Add(new Claim("color", "red"));
                    await signInManager.SignInAsync(user, true);
                    return Ok(user);
                }
                    //return BadRequest(result.Errors.First());
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("password", item.Description);
                }
                return BadRequest(ModelState);         
            }

            return BadRequest(registerDTO);

        }

    }
}
