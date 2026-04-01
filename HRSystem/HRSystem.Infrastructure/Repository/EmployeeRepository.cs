using Hr.Application.Interfaces;
using Hr.Domain.Entities;
using HRSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDBContext context;

        public EmployeeRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Employee employee)
        {
           context.Employees.Update(employee);
        }
    }
}
