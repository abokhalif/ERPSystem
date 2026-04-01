using Hr.Domain.Entities;
using Hr.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Infrastructure.Data;

namespace Hr.Infrastructure.Repository
{
    public class PublicHolidaysRepository :Repository<PublicHolidays>,IPublicHolidaysRepository
    {

        private readonly ApplicationDBContext context;
        public PublicHolidaysRepository(ApplicationDBContext context): base(context)
        {
            this.context = context;
        }

        public void Update(PublicHolidays publicHoliday)
        {
            context.Update(publicHoliday);
        }









    }
}
