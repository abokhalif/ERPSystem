using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.UserService
{
    public interface IUserService
    {
        Task<AuthenticationResponseDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDTO);
        Task<AuthenticationResponseDTO> RefreshTokenAsync(string token, string refreshToken);
        Task<ProfileDTO> GetProfileAsync(string userId);
        Task<bool> UpdateProfileAsync(ProfileDTO profileDTO, string userId);
        Task<AuthenticationResponseDTO> ChangePasswordAsync(string userId, ChangePasswordDTO changePasswordDTO);
        Task<bool> DeactivateAccountAsync(string userId);
    }
}
