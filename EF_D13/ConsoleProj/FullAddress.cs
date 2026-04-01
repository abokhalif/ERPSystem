using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProj
{
    // Owned Entity => represent Composite Attribute in ERD As (Address , FullName)
    // not has PK or ID

    [Owned]
    internal class FullAddress
    {
        [MaxLength(50)]
        [Required]
        public string FLine { get; set; }

        public int ZipCode  { get; set; }

        [Required]
        public string City { get; set; }

        [StringLength(2,MinimumLength =2)]
        [Required]
        public int CountryCode { get; set; }



    }
}
