using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF1.Models
{
    //[Index(nameof(Name),nameof(Url), Name = "Url_Ix", IsUnique = true)]// composed Index
    // [Index(nameof(Url),Name ="Url_Ix",IsUnique =true)]// single index
    internal class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; }

        public List<Post> Posts { get; set; }////Navigational Property
    }
}
