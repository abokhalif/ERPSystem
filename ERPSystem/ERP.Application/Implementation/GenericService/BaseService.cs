using ERP.API.ResponseModels;
using ERP.Application.Interfaces;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Application.ResponseModels;

namespace ERP.Application.Implementation.GenericService
{
    /// <summary>
    /// Base service class with common operations and response handling.
    /// </summary>
    public abstract class BaseService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<BaseService<T>> _logger;
        protected readonly IRepository<T> _repository;

        protected BaseService(IUnitOfWork unitOfWork, ILogger<BaseService<T>> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = _unitOfWork.Repository<T>();
        }

        /// <summary>
        /// Gets an entity by ID asynchronously.
        /// </summary>
        public virtual async Task<ApiResponse<T>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ApiResponse<T>.FailureResponse("Invalid ID provided", new List<string> { "ID must be positive" }, 400);

                var entity = await _repository.GetAsync(id);

                if (entity == null)
                    return ApiResponse<T>.FailureResponse($"{typeof(T).Name} not found", statusCode: 404);

                _logger.LogInformation($"{typeof(T).Name} with ID {id} retrieved successfully");
                return ApiResponse<T>.SuccessResponse(entity, $"{typeof(T).Name} retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving {typeof(T).Name} with ID {id}");
                return ApiResponse<T>.ErrorResponse(ex, 500);
            }
        }

        /// <summary>
        /// Gets all entities asynchronously.
        /// </summary>
        public virtual async Task<ApiResponse<T>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                _logger.LogInformation($"Retrieved {entities.Count} {typeof(T).Name} entities");
                return PagedApiResponse<T>.SuccessListedData(entities, $"All {typeof(T).Name} retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving all {typeof(T).Name} entities");
                return ApiResponse<T>.ErrorResponse(ex, 500);
            }
        }

        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        public virtual async Task<BaseApiResponse> CreateAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return BaseApiResponse.FailureResponse("Entity cannot be null", new List<string> { "Provide valid entity data" }, 400);

                await _unitOfWork.BeginTransactionAsync();
                await _repository.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation($"New {typeof(T).Name} created successfully");
                return BaseApiResponse.SuccessResponse( $"{typeof(T).Name} created successfully", 201);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, $"Error creating new {typeof(T).Name}");
                return BaseApiResponse.ErrorResponse(ex, 500);
            }
        }

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        public virtual async Task<ApiResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                    return ApiResponse<T>.FailureResponse("Entity cannot be null", new List<string> { "Provide valid entity data" }, 400);

                await _unitOfWork.BeginTransactionAsync();
                _repository.Update(entity);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation($"{typeof(T).Name} updated successfully");
                return ApiResponse<T>.SuccessResponse(entity, $"{typeof(T).Name} updated successfully");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, $"Error updating {typeof(T).Name}");
                return ApiResponse<T>.ErrorResponse(ex, 500);
            }
        }

        /// <summary>
        /// Deletes an entity by ID asynchronously.
        /// </summary>
        public virtual async Task<BaseApiResponse> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BaseApiResponse.FailureResponse("Invalid ID provided", new List<string> { "ID must be positive" }, 400);

                var entity = await _repository.GetAsync(id);

                if (entity == null)
                    return BaseApiResponse.FailureResponse($"{typeof(T).Name} not found", statusCode: 404);

                await _unitOfWork.BeginTransactionAsync();
                _repository.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                _logger.LogInformation($"{typeof(T).Name} with ID {id} deleted successfully");
                return BaseApiResponse.SuccessResponse($"{typeof(T).Name} deleted successfully");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _logger.LogError(ex, $"Error deleting {typeof(T).Name}");
                return BaseApiResponse.ErrorResponse(ex, 500);
            }
        }

        /// <summary>
        /// Gets entities with specification asynchronously.
        /// </summary>
        public virtual async Task<ApiResponse<T>> GetPagedWithMetaAsync(ISpecification<T> spec)
        {
            try
            {
                if (spec == null)
                    return ApiResponse<T>.FailureResponse("Specification cannot be null", new List<string> { "Provide valid specification" }, 400);

                var (data, meta) = await _repository.GetPagedWithMetaAsync(spec);
                _logger.LogInformation($"Retrieved {data.Count} {typeof(T).Name} entities with specification");
                return PagedApiResponse<T>.SuccessWithPagingMetaData(data, meta, $"{typeof(T).Name} retrieved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving {typeof(T).Name} with specification");
                return ApiResponse<T>.ErrorResponse(ex, 500);
            }
        }
    }
}
