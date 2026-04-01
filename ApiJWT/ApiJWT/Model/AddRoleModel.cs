using System.ComponentModel.DataAnnotations;

namespace ApiJWT.Model
{
    public class AddRoleModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
