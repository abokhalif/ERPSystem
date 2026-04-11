using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategoryFeatures.DTOs
{
    public class CategoryWithHierarchyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int DisplayOrder { get; set; }

        public List<CategoryWithHierarchyResponse> ChildCategories { get; set; } = new();

        public List<CategoryProductResponse> Products { get; set; } = new();
    }

    /// <summary>
    /// Response DTO for product in category.
    /// </summary>
    public class CategoryProductResponse
    {
 
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
    }

}
