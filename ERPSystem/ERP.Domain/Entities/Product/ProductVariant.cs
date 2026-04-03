using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities.Product
{
    public class ProductVariant:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string SKU { get; set; } = null!;

        public ICollection<VariantValue> VariantValues { get; set; }
            = new List<VariantValue>();
    }
}
