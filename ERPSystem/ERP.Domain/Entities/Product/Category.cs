using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities.Product
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category? ParentCategory { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; } = new List<Category>();

        
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public int DisplayOrder { get; set; }

      
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }

}
