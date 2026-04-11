using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategoryFeatures.DTOs
{
    public class UpdateCategoryRequest
    {
 
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        [Range(0, int.MaxValue)]
        public int DisplayOrder { get; set; }

        
    }
}
