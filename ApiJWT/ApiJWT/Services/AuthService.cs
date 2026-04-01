//namespace ApiJWT.Services
using ApiJWT.Helpers;
using ApiJWT.Model;
using ApiJWT.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
//using ApiJWT.Helpers;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiJWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new AuthModel { Message = "Username is already registered!" };

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                SecondName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);

            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new AuthModel
            {
                Email = user.Email,
               // ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn
            };
        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var rolesList = await _userManager.GetRolesAsync(user);
            var jwtSecurityToken = await CreateJwtToken(user);


            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            // authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            //check if the user has any activated refresh token 
            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken?.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else // if not has create a new one and save it to the database 
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            return authModel;
        }
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.email);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something went wrong";
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim("roles", role)).ToList();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),//JWT ID (jti) Claim:Provides a unique identifier for the token, which can be used to prevent replay attacks.
                new Claim(JwtRegisteredClaimNames.Email, user.Email),//Identifies the subject of the token, which is typically the user's username.
                new Claim("uid", user.Id) 
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                ////////////////////////////////////////////////////*****************
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInDays),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }
        //public async Task<AuthModel> LoginAsync(LoginModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);

        //    if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        //    {
        //        return new AuthModel { Message = "Email or Password is incorrect!" };
        //    }

        //    var jwtSecurityToken = await CreateJwtToken(user);

        //    // Generate or retrieve refresh token
        //    var refreshToken = GenerateRefreshToken();

        //    return new AuthModel
        //    {
        //        Email = user.Email,
        //        IsAuthenticated = true,
        //        Roles = await _userManager.GetRolesAsync(user),
        //        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
        //        UserName = user.UserName,
        //        RefreshToken = refreshToken.Token,
        //        RefreshTokenExpiration = refreshToken.ExpiresOn
        //    };
        //}






        //public async Task<AuthModel> RefreshTokenAsync(string token)
        //{
        //    var authModel = new AuthModel();

        //    var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

        //    if (user == null)
        //    {
        //        authModel.Message = "Invalid token";
        //        return authModel;
        //    }

        //    var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

        //    if (!refreshToken.IsActive)
        //    {
        //        authModel.Message = "Inactive token";
        //        return authModel;
        //    }

        //    refreshToken.RevokedOn = DateTime.UtcNow;

        //    var newRefreshToken = GenerateRefreshToken();
        //    user.RefreshTokens.Add(newRefreshToken);
        //    await _userManager.UpdateAsync(user);

        //    var jwtToken = await CreateJwtToken(user);
        //    authModel.IsAuthenticated = true;
        //    authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        //    authModel.Email = user.Email;
        //    authModel.UserName = user.UserName;
        //    var roles = await _userManager.GetRolesAsync(user);
        //    authModel.Roles = roles.ToList();
        //    authModel.RefreshToken = newRefreshToken.Token;
        //    authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

        //    return authModel;
        //}

        //public async Task<bool> RevokeTokenAsync(string token)
        //{
        //    var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

        //    if (user == null)
        //        return false;

        //    var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

        //    if (!refreshToken.IsActive)
        //        return false;

        //    refreshToken.RevokedOn = DateTime.UtcNow;

        //    await _userManager.UpdateAsync(user);

        //    return true;
        //}

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),

                /////////////////////////////////////*****************
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }
        public async Task<List<string>> GetRolesAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new List<string> { "this email not found"};

            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

       


    }
}