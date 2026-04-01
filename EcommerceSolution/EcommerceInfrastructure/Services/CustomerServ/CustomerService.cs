using EcommerceApplication.Contracts;
using EcommerceApplication.Interfaces;
using EcommerceApplication.IServices.ICustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Services.CustomerService
{
    internal sealed class CustomerService: ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CustomerService(IRepositoryManager repository, ILoggerManager
      logger)
        {
            _repository = repository;
            _logger = logger;
        }

    }
}
