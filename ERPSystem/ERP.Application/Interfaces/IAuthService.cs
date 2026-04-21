using ERP.Application.DTOs;
using ERP.Persistence.Implementation.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticationResponseDTO> RegisterAsync(RegisterRequest registerDTO);
        Task<AuthenticationResponseDTO> LoginAsync(LoginRequest loginDTO);
        Task<AuthenticationResponseDTO> RefreshTokenAsync(string token, string refreshToken);
        Task<ProfileDTO> GetProfileAsync(string userId);
         Task<bool> UpdateProfileAsync(ProfileDTO profileDTO, string userId);
        Task<bool> DeactivateAccountAsync(string userId);
        public Task<AuthenticationResponseDTO> ChangePasswordAsync(string userId, ChangePasswordDTO changePasswordDTO);



    }
}
