using ERP.API.ResponseModels;
using ERP.Application.Features.CategoryFeatures.DTOs;
using ERP.Application.Features.CategoryFeatures.Interface;
using ERP.Application.Features.CategoryFeatures.Specifications;
using ERP.Application.Implementation.GenericService;
using ERP.Application.Interfaces;
using ERP.Application.ResponseModels;
using ERP.Domain.Entities.Product;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategoryFeatures.Implementation
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, ILogger<BaseService<Category>> logger) : base(unitOfWork, logger)
        {
        }

        public Task<ApiResponse<bool>> CheckCategoryNameExistsAsync(string name, int? excludeCategoryId = null)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<int>> CountProductsInCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<CategoryWithHierarchyResponse>> GetCategoryWithHierarchyAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<CategoryWithHierarchyResponse>>> GetRootCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedApiResponse<CategoryResponse>> SearchCategoriesAsync(string? searchTerm, int pageNumber = 1, int pageSize = 10)
        {

            if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
            {

                return PagedApiResponse<CategoryResponse>.FailureResponse(new List<string> { "PageNumber >= 1", "PageSize between 1-100" },
                    "Invalid paging parameters",
                    400);
            }

            var spec = new GetCategoriesSpecification(searchTerm, pageNumber, pageSize);
            if(spec == null)
                return PagedApiResponse<CategoryResponse>.ErrorResponse( new NullReferenceException(),null, 500);
            var response = await GetPagedWithMetaAsync(spec);
            // Map to response DTOs
            var categoryResponses = response.Data?.Select(MapToCategoryResponse).ToList() ?? new();

            var pagedResponse = PagedApiResponse<CategoryResponse>.SuccessWithMetaData(
                categoryResponses,
                response.MetaData,
                "Categories retrieved successfully");

            return pagedResponse;
        }


        
            
        

     private CategoryResponse MapToCategoryResponse(Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ParentCategoryId = category.ParentCategoryId,
                ParentCategoryName = category.ParentCategory?.Name,
                DisplayOrder = category.DisplayOrder,
                ProductCount = category.Products?.Count ?? 0,
                ChildCategoryCount = category.ChildCategories?.Count ?? 0,
                CreatedAt = category.CreatedAt,
            };
        }
    }
}
