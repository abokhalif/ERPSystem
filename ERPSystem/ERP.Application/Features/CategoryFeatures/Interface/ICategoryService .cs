using ERP.API.ResponseModels;
using ERP.Application.Features.CategoryFeatures.DTOs;
using ERP.Application.Interfaces.IGenericServices;
using ERP.Application.ResponseModels;
using ERP.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategoryFeatures.Interface
{
    /// <summary>
    /// Service interface for Category operations.
    /// </summary>
    public interface ICategoryService :IBaseService<Category>,IService<Category>
    {
       
        Task<PagedApiResponse<CategoryResponse>> SearchCategoriesAsync(
            string? searchTerm,
            int pageNumber = 1,
            int pageSize = 10);
        Task<ApiResponse<List<CategoryWithHierarchyResponse>>> GetRootCategoriesAsync();
        Task<ApiResponse<CategoryWithHierarchyResponse>> GetCategoryWithHierarchyAsync(int categoryId);

        Task<ApiResponse<bool>> CheckCategoryNameExistsAsync(string name, int? excludeCategoryId = null);

        Task<ApiResponse<int>> CountProductsInCategoryAsync(int categoryId);
    }
}
