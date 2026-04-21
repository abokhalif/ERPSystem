using ERP.Application.Interfaces;
using ERP.Persistence.Entities;
using ERP.Persistence.Entities.Authentication;
using ERP.Persistence.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistence.Implementation.Shared
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;


        public JwtService(IConfiguration config, UserManager<ApplicationUser> userManager , AppDbContext context)
        {
            _config = config;
            _userManager = userManager;
            _context = context;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.GivenName, user.FullName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
             new Claim(ClaimTypes.Role, role)
                };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                 expires: DateTime.Now.AddHours(2),

                claims: claims,
               
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(ApplicationUser user)
        {
            var randomBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = user.Id
            };
           _context.AddAsync(refreshToken);   
            _context.SaveChanges();
            return refreshToken;
        }
        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out _);

                return principal;
            }
            catch
            {
                throw new Exception();
            }
        }
        public  async Task <RefreshToken> GetValidRefreshTokenAsync(string refreshToken, string userId)
        {
            if (refreshToken != null||userId!=null)
            {
               await _context.RefreshTokens
                .Where(rt => rt.Token == refreshToken && rt.UserId == userId && !rt.IsRevoked && rt.ExpiryDate > DateTime.UtcNow)
                .FirstOrDefaultAsync();
            }
            throw new NullReferenceException();
        }

        public async Task RevokeRefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);
            if (token != null)
            {
                token.IsRevoked = true;
                _context.RefreshTokens.Update(token);
                await _context.SaveChangesAsync();
            }
        }

    }
}
