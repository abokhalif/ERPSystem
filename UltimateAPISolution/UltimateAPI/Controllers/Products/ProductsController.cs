using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltimateCore.IRepositories;
using UltimateCore.Entities;
using UltimateCore.Specifications;
using UltimateCore.Specifications.ProductSpec;
using AutoMapper;
using UltimateAPI.Dtos;
using UltimateAPI.Errors;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using UltimateAPI.Helpers;
using UltimateCore.Shared.RequestFeatures;

namespace UltimateAPI.Controllers.Products
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> repository;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductCategory> categoryRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> repository

            , IGenericRepository<ProductBrand> brandRepo
            , IGenericRepository<ProductCategory> categoryRepo
            , IMapper mapper)
        {
            this.repository = repository;
            this.brandRepo = brandRepo;
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
        }

        [HttpGet("AllProducts")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]RequestParameters parameters,int? brandId, int? categoryId,string? serchTerm)
        {
            // 1. Create specification with paging and filtering
            var spec = new ProductWithBrandAndCategorySpec(serchTerm,brandId, categoryId, parameters.PageNumber, parameters.PageSize);

            // 2. Get paged data with meta from generic repository
            var (products, metaData) = await repository.GetPagedWithMetaAsync(spec);

            // 3. Map to DTO
            var mapped = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToDto>>(products);

            // 4. Return wrapped API response with metadata
            return Ok(ApiResponse<IReadOnlyList<ProductToDto>>.SuccessWithPagingMetaData(mapped, metaData));



            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<ProductToDto>>> GetProduct(int id)
        {
            ISpecifications<Product> spec = new ProductWithBrandAndCategorySpec(id);
            var product = await repository.GetWithSpecAsync(spec);
            if (product is null)
                return NotFound();
            var result = mapper.Map<Product, ProductToDto>(product);
            return Ok(ApiResponse<ProductToDto>.Success(result));
        }
        [HttpGet("AllBrands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> AllBrands()
        {
           return   Ok( await brandRepo.GetAllAsync());
        }
        [HttpGet("AllCategories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> AllCategories()
        {
            var result = await categoryRepo.GetAllAsync();
            return Ok(ApiResponse<IReadOnlyList< ProductCategory >>.Success(result));
        }
    }
}
