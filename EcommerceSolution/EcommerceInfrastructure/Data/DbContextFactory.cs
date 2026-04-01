using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace EcommerceInfrastructure.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
       

        public AppDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + "/../EcommerceAPI";
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
            var conString=configuration.GetConnectionString("DefaultConnection");
            var optionbuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionbuilder.UseSqlServer(conString);
            return new AppDbContext(optionbuilder.Options);
        }
    }
}
