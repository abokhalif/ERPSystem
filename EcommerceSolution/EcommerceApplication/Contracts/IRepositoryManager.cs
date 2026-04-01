using EcommerceApplication.Contracts.ICustomerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        ICustomerRepo Customers { get; }
        Task<int> SaveAsync(); // Save changes
    }
}
