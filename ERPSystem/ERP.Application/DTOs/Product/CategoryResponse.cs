using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs.Product
{
    /// <summary>
    /// Response DTO for category.
    /// </summary>
    public class CategoryResponse
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public string? ParentCategoryName { get; set; }

  
        public int DisplayOrder { get; set; }

        public int ProductCount { get; set; }

        public int ChildCategoryCount { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
