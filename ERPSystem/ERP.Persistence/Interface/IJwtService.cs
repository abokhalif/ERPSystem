using ERP.Persistence.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistence.Interface

{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);
         RefreshToken GenerateRefreshToken(ApplicationUser user);
        ClaimsPrincipal ValidateJwtToken(string token);
       Task< RefreshToken> GetValidRefreshTokenAsync(string refreshToken, string userId);
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
