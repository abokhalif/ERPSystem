using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities.Product
{
    public class Product :BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal BasePrice { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }

        public ICollection<ProductVariant> Variants { get; set; }
            = new List<ProductVariant>();
    }
}
