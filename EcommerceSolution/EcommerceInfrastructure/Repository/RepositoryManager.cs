using EcommerceApplication.Contracts.ICustomerRepo;
using EcommerceApplication.Interfaces;
using EcommerceInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceInfrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;

        public readonly Lazy<ICustomerRepo> CustomerRepo;

        public RepositoryManager(AppDbContext dbContext)
        {
            _context = dbContext;
            CustomerRepo = new Lazy<ICustomerRepo>(()=>new CustomerRepo.CustomerRepo(dbContext));
        }
        public ICustomerRepo Customers=> CustomerRepo.Value;

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
