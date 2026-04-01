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
    public class WeekendRepository:Repository<Weekend>,IWeekendRepository
    {
        ApplicationDBContext context;
        public WeekendRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }
        public void update(Weekend weekend)
        {
            context.Update(weekend);
        }

    }
}
