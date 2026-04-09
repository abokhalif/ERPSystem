using ERP.Application.Shared;
using ERP.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategorySpec
{
    /// <summary>
    /// Specification for getting categories with pagination.
    /// </summary>
    public class GetCategoriesSpecification : BaseSpecification<Category>
    {
        public GetCategoriesSpecification(string? searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            // Apply filtering
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                Criteria = c => c.Name.Contains(searchTerm) || c.Description!.Contains(searchTerm);
            }

            AddInclude(c => c.ParentCategory);
            AddInclude(c => c.ChildCategories);

            AddOrderBy(c => c.DisplayOrder);
            AddOrderBy(c => c.Name);

            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 100) pageSize = 100;

            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
        }
    }
}
