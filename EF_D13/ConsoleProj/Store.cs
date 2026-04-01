using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProj
{
    internal class Store
    {
        public int Id { get; set; } 
        public DateTime OpenDate { get; set; }
        [Required]
        public FullAddress StoreAddress { get; set; } 
         public byte SartHr { get; set; }
        public byte EndHr { get; set; }

    }
}
