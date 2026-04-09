using ERP.API.ResponseModels;
using ERP.Application.Implementation.Services;
using ERP.Application.Interfaces;
using ERP.Application.Interfaces.IGenericServices;
using ERP.Application.ResponseModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Implementation.GenericService
{
    /// <summary>
    /// Service class implementing complex query operations using specifications.
    /// Extends BaseService for basic CRUD operations.
    /// </summary>
    public abstract class Service<T> : BaseService<T>, IService<T> where T : class
    {
        protected Service(IUnitOfWork unitOfWork, ILogger<BaseService<T>> logger)
            : base(unitOfWork, logger)
        {
        }
        
        /// <summary>
        /// Gets entities with specification asynchronously.
        /// </summary>
        public virtual async Task<PagedApiResponse<T>> GetEntitiesWithSpecAsync(ISpecification<T> spec)
        {
            var entityName = typeof(T).Name;

            try
            {
                if (spec == null)
                {
                    return PagedApiResponse<T>.FailureResponse(new List<string> { "Provide valid specification" },
                        "Specification cannot be null", 400);
                }


                var (data, meta) = await _repository.GetPagedWithMetaAsync(spec);

                _logger.LogInformation("Successfully retrieved {Count} {Entity} records with specification ",
                    data.Count, entityName);
                return PagedApiResponse<T>.SuccessWithMetaData(
                    data,
                    meta,
                    $"{entityName} retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving {Entity} with specification ",
                    entityName);
                return PagedApiResponse<T>.ErrorResponse(ex,null ,500);
            }
        }

        /// <summary>
        /// Gets a single entity matching the specification asynchronously.
        /// </summary>
        public virtual async Task<ApiResponse<T>> GetEntityWithSpecAsync(ISpecification<T> spec)
        {
            var entityName = typeof(T).Name;

            try
            {
                if (spec == null)
                {
                    return ApiResponse<T>.FailureResponse(new List<string> { "Provide valid specification" },
                        "Specification cannot be null",400);
                }


                var entity = await _repository.GetEntityWithSpecAsync(spec);

                if (entity == null)
                {
                    return ApiResponse<T>.FailureResponse(null,$"{entityName} not found");
                }
                _logger.LogInformation($"{typeof(T).Name} retrieved successfully");


                return ApiResponse<T>.SuccessResponse(
                    entity,
                    $"{entityName} retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving single {Entity} with specification after ",
                    entityName);
                return ApiResponse<T>.ErrorResponse(ex,null, 500);
            }
        }

        /// <summary>
        /// Counts entities matching the specification asynchronously.
        /// </summary>
        public virtual async Task<ApiResponse<int>> CountAsync(ISpecification<T> spec)
        {
            var entityName = typeof(T).Name;

            try
            {
                if (spec == null)
                {
                    return ApiResponse<int>.FailureResponse(new List<string> { "Provide valid specification" },
                        "Specification cannot be null", 400);
                }


                var count = await _repository.CountAsync(spec);


                _logger.LogInformation("Successfully counted {Entity} (count: {Count})",
                    entityName, count);

                return ApiResponse<int>.SuccessResponse(
                    count,
                    $"{entityName} count retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error counting {Entity} ",
                    entityName);
                return ApiResponse<int>.ErrorResponse(ex, null,500);
            }
        }

        /// <summary>
        /// Checks if any entity exists matching the specification.
        /// </summary>
        public virtual async Task<ApiResponse<bool>> AnyAsync(ISpecification<T> spec)
        {
            var entityName = typeof(T).Name;

            try
            {
                if (spec == null)
                {
                    return ApiResponse<bool>.FailureResponse(new List<string> { "Provide valid specification" },
                        "Specification cannot be null",
                        400);
                }


                var count = await _repository.CountAsync(spec);
                var exists = count > 0;


                _logger.LogInformation("Existence check for {Entity} completed: {Exists}",
                    entityName, exists);

                return ApiResponse<bool>.SuccessResponse(
                    exists,
                    $"{entityName} existence check completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking {Entity} existence ",
                    entityName);
                return ApiResponse<bool>.ErrorResponse(ex,null, 500);
            }
        }

        
    }
}
