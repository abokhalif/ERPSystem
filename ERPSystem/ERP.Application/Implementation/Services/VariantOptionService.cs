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
    public class VariantOptionService : BaseService<VariantOptions>, IVariantOptionService
    {
        public VariantOptionService(IUnitOfWork unitOfWork, ILogger<BaseService<VariantOptions>> logger) 
            : base(unitOfWork, logger)
        {
        }
    }
}
