using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public decimal BasePrice { get; set; }
    }

}
