using EcommerceApplication.Contracts.ICustomerRepo;
using EcommerceCore.Entities;
using EcommerceInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceInfrastructure.Repository.CustomerRepo
{
    public class CustomerRepo : RepositoryBase<Customer>, ICustomerRepo
    {
        public CustomerRepo(AppDbContext Context) : base(Context)
        {

        }
    }
}
