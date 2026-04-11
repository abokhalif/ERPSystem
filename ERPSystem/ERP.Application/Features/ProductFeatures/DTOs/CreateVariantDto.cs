using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.ProductFeatures.DTOs
{
    public class CreateVariantDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; } = null!;

        public List<CreateVariantValueDto> Values { get; set; } = new();
    }

}
