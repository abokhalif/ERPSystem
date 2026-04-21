using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistence.Entities.Authentication
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAccountActive { get; set; } = true;
        public ICollection<RefreshToken>? RefreshTokens { get; set; }

    }
}
