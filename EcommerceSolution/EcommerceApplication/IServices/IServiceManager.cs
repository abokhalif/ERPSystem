using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.IServices
{
    public interface IServiceManager
    {
        ICustomerService.ICustomerService CustomerService { get; } 
    }
}
