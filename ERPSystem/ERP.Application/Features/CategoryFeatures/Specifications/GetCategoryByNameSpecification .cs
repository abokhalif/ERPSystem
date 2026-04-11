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
    /// Specification for getting category by name.
    /// </summary>
    public class GetCategoryByNameSpecification : BaseSpecification<Category>
    {
        public GetCategoryByNameSpecification(string name)
        {
            Criteria = c => c.Name == name;
        }
    }
}
