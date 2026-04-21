using ERP.Application.DTOs;
using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Persistence.Interface;
using ERP.Persistence.Entities.Authentication;
using ERP.Persistence.Implementation.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Implementation.Shared
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(UserManager<ApplicationUser> userManager,
                           IJwtService jwtService,
                           RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        public async Task<AuthenticationResponseDTO> RegisterAsync(RegisterRequest registerDTO)
        {
            var user = new ApplicationUser
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                FullName = registerDTO.FullName,
                IsAccountActive = true
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }

                await _userManager.AddToRoleAsync(user, "User");

                var jwtToken = await _jwtService.GenerateTokenAsync(user);
                var refreshToken = _jwtService.GenerateRefreshToken(user);

                return new AuthenticationResponseDTO
                {
                    Token = jwtToken,
                    UserId = user.Id,
                    RefreshToken = refreshToken.Token
                };
            }

            return new AuthenticationResponseDTO { Errors = result.Errors.Select(e => e.Description) };
        }

        public async Task<AuthenticationResponseDTO> LoginAsync(LoginRequest loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null || !user.IsAccountActive)
            {
                return new AuthenticationResponseDTO { Errors = new[] { "Invalid credentials." } };
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!result)
            {
                return new AuthenticationResponseDTO { Errors = new[] { "Invalid credentials." } };
            }

            var jwtToken = await _jwtService.GenerateTokenAsync(user);
            var refreshToken = _jwtService.GenerateRefreshToken(user);

            return new AuthenticationResponseDTO
            {
                Token = jwtToken,
                UserId = user.Id,
                RefreshToken = refreshToken.Token
            };
        }

        public async Task<AuthenticationResponseDTO> RefreshTokenAsync(string token, string refreshToken)
        {
            var principal = _jwtService.ValidateJwtToken(token);
            if (principal == null)
            {
                return new AuthenticationResponseDTO { Errors = new[] { "Invalid JWT token." } };
            }

            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var validRefreshToken =  _jwtService.GetValidRefreshTokenAsync(refreshToken, userId);

            if (validRefreshToken == null)
            {
                return new AuthenticationResponseDTO { Errors = new[] { "Invalid or expired refresh token." } };
            }

            await _jwtService.RevokeRefreshTokenAsync(refreshToken);

            var newJwtToken = await _jwtService.GenerateTokenAsync(await _userManager.FindByIdAsync(userId));
            var newRefreshToken = _jwtService.GenerateRefreshToken(await _userManager.FindByIdAsync(userId));

            return new AuthenticationResponseDTO
            {
                Token = newJwtToken,
                UserId = userId,
                RefreshToken = newRefreshToken.Token
            };
        }
        public async Task<ProfileDTO> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;

            return new ProfileDTO
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        public async Task<bool> UpdateProfileAsync(ProfileDTO profileDTO, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.FullName = profileDTO.FullName;
            user.Email = profileDTO.Email;
            user.PhoneNumber = profileDTO.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeactivateAccountAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.IsAccountActive = false;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public Task<AuthenticationResponseDTO> ChangePasswordAsync(string userId, ChangePasswordDTO changePasswordDTO)
        {
            throw new NotImplementedException();
        }

    }
}
