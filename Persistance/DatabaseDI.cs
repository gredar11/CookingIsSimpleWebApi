using Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    // database dependency injection
    public static class DatabaseDI
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CisDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebApi")));
        }
    }
}
