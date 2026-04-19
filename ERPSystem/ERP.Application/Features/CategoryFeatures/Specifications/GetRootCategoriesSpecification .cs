using ERP.Application.Shared;
using ERP.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategoryFeatures.Specifications
{
    public class GetRootCategoriesSpecification : BaseSpecification<Category>
    {
        public GetRootCategoriesSpecification()
        {
            Criteria = c => c.ParentCategoryId == null;
            AddInclude(c => c.ChildCategories);
            AddOrderBy(c => c.DisplayOrder);
        }
    }
}
