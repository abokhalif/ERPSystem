using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities.Product
{
    public class VariantValue:BaseEntity
    {
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;

        public int VariantOptionId { get; set; }
        public VariantOption Option { get; set; } = null!;

        public string Value { get; set; } = null!;
    }
}
