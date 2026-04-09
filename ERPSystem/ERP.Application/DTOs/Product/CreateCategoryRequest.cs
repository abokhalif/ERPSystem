using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.DTOs.Product
{
    public class CreateCategoryRequest
    {
      
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(200, MinimumLength = 2,
            ErrorMessage = "Category name must be between 2 and 200 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }

        [Range(0, int.MaxValue)]
        public int DisplayOrder { get; set; } = 0;

    }
}
