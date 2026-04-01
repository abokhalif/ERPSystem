using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RefreshTokenRequestDTO
    {
        public string Token { get; set; }   // JWT
        public string RefreshToken { get; set; }   // Refresh Token
    }
}
