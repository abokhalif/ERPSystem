using DAL.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public interface IJwtHelper
    {
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
        RefreshToken GenerateRefreshToken(ApplicationUser user);
        ClaimsPrincipal ValidateJwtToken(string token);
        Task<RefreshToken> GetValidRefreshTokenAsync(string refreshToken, string userId);
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
