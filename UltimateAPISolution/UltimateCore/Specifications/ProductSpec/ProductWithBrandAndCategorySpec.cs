using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCore.Entities;
using UltimateCore.Shared.RequestFeatures;

namespace UltimateCore.Specifications.ProductSpec
{
    public class ProductWithBrandAndCategorySpec:BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpec(int? brandId,int? categoryId) :base(
            p=>
            (!brandId.HasValue||p.ProductBrandId==brandId) &&
            (!categoryId.HasValue||p.ProductCategoryId==categoryId)
            ) 
        {
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductBrand);

            AddOrderBy(p => p.Name, false);
            AddOrderBy(p => p.Price, true);

        }
        public ProductWithBrandAndCategorySpec(string? serchTerm, int? brandId, int? categoryId, int pageNumber = 1, int pageSize = 5) :
            base(p =>
           (string.IsNullOrEmpty(serchTerm) || p.Name.ToLower().Contains(serchTerm.ToLower())) &&
           (!brandId.HasValue || p.ProductBrandId == brandId) &&
           (!categoryId.HasValue || p.ProductCategoryId == categoryId)
           ) //to get all products with category and brands
        {
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductBrand);

            ApplyPaging(pageNumber, pageSize);

            AddOrderBy(p => p.Name, false);
            AddOrderBy(p => p.Price, true);


        }
        public ProductWithBrandAndCategorySpec(int id):base(p=>p.Id==id)
        {
            Includes.Add(p => p.ProductCategory);
            Includes.Add(p => p.ProductBrand);

          


        }



    }
}
