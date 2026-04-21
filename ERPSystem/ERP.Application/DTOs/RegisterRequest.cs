using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(100, ErrorMessage = "User name is required and must be between 2 and 100 characters.", MinimumLength = 2)]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "Full name is required and must be between 2 and 100 characters.", MinimumLength = 2)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
