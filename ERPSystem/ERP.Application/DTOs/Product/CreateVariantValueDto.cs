using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs.Product
{
    public class CreateVariantValueDto
    {
        public int VariantOptionId { get; set; }
        public string Value { get; set; } = null!;
    }

}
