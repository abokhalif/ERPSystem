using ERP.Application.Implementation.GenericService;
using ERP.Application.Interfaces;
using ERP.Application.Interfaces.IServices;
using ERP.Domain.Entities.Product;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Implementation.Services
{
    public class ProductVariantService : BaseService<ProductVariant>, IProductVariantService
    {
        public ProductVariantService(IUnitOfWork unitOfWork, ILogger<BaseService<ProductVariant>> logger): base(unitOfWork, logger)
        {
        }
    }
}
