using System.ComponentModel.DataAnnotations;

namespace HRSystemWEB.Areas.Auth.Models
{
    public class LoginUserDto
    {
        [Required]
        public string EmailOrUserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
