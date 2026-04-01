using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    [Keyless]
    public class RoleViewModel
    {
        [Required]
        public string Role { get; set; }
    }
}
