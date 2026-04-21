using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }  
        public string RefreshToken { get; set; }  
        public string UserId { get; set; }
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();   // In case of errors
    }
}
