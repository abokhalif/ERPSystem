using BLL.DTOs;
using BLL.Helper;
using BLL.Services.UserService;
using DAL.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtHelper _jwtHelper;

    public UserService(UserManager<ApplicationUser> userManager, IJwtHelper jwtHelper, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _jwtHelper = jwtHelper;
        _roleManager = roleManager;
    }

    public async Task<AuthenticationResponseDTO> RegisterAsync(RegisterDTO registerDTO)
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

            var jwtToken = await _jwtHelper.GenerateJwtTokenAsync(user);
            var refreshToken = _jwtHelper.GenerateRefreshToken(user);

            return new AuthenticationResponseDTO
            {
                Token = jwtToken,
                UserId = user.Id,
                RefreshToken = refreshToken.Token
            };
        }

        return new AuthenticationResponseDTO { Errors = result.Errors.Select(e => e.Description) };
    }

    public async Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDTO)
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

        var jwtToken = await _jwtHelper.GenerateJwtTokenAsync(user);
        var refreshToken = _jwtHelper.GenerateRefreshToken(user);

        return new AuthenticationResponseDTO
        {
            Token = jwtToken,
            UserId = user.Id,
            RefreshToken = refreshToken.Token
        };
    }

    public async Task<AuthenticationResponseDTO> RefreshTokenAsync(string token, string refreshToken)
    {
        var principal = _jwtHelper.ValidateJwtToken(token);
        if (principal == null)
        {
            return new AuthenticationResponseDTO { Errors = new[] { "Invalid JWT token." } };
        }

        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        var validRefreshToken = await _jwtHelper.GetValidRefreshTokenAsync(refreshToken, userId);

        if (validRefreshToken == null)
        {
            return new AuthenticationResponseDTO { Errors = new[] { "Invalid or expired refresh token." } };
        }

        await _jwtHelper.RevokeRefreshTokenAsync(refreshToken);

        var newJwtToken = await _jwtHelper.GenerateJwtTokenAsync(await _userManager.FindByIdAsync(userId));
        var newRefreshToken = _jwtHelper.GenerateRefreshToken(await _userManager.FindByIdAsync(userId));

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
