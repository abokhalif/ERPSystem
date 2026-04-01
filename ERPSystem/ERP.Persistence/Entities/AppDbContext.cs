using ERP.Persistence.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistence.Entities
{
    internal class AppDbContext: IdentityDbContext<ApplicationUser>
    {


    }
}
