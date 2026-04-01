using EcommerceApplication.Contracts;
using EcommerceApplication.Interfaces;
using EcommerceApplication.IServices;
using EcommerceApplication.IServices.ICustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _companyService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _companyService = new Lazy<ICustomerService>(() => new
                CustomerService.CustomerService(repositoryManager, logger));
        }
        public ICustomerService CustomerService => _companyService.Value;
    }
}
