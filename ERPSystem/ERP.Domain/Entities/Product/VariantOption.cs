using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities.Product
{
    public class VariantOption:BaseEntity 
    {
        public string Name { get; set; } = null!;
    }
}
