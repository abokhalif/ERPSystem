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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDBContext context;

        public DepartmentRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public void Update(Department department)
        {
           context.Update(department);
        }
    }
}
