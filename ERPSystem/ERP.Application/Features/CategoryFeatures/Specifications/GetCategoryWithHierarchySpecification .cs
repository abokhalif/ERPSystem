using ERP.Application.Shared;
using ERP.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategoryFeatures.Specifications
{
    /// <summary>
    /// Specification for getting category with child categories and products.
    /// </summary>
    public class GetCategoryWithHierarchySpecification : BaseSpecification<Category>
    {
        public GetCategoryWithHierarchySpecification(int categoryId)
        {
            Criteria = c => c.Id == categoryId;
            AddInclude(c => c.ChildCategories);
            AddInclude(c => c.Products);
            EnableTracking();
        }
    }
}
