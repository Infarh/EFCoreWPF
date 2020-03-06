using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.Data
{
    public static class DatabaseServicesExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<Database>(opt => opt.UseSqlServer(ConnectionString));
            services.AddTransient<DatabaseInitializer>();
            services.AddSingleton<DatabaseManager>();

            return services;
        }
    }
}
