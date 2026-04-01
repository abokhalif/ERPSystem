using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.DTO
{
    public class RoleDTO
    {
        [Required]
        public string RoleName { get; set; }
    }
}
