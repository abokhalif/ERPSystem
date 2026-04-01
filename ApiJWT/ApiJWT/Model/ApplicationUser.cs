using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApiJWT.Model
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }


    }
}
