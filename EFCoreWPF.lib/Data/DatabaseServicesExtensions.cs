using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.Data
{
    public static class DatabaseServicesExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string ConnectionString)
        {
            if(string.IsNullOrWhiteSpace(ConnectionString))
                throw new InvalidOperationException("Указана пустая строка подключения к БД");

            services.AddDbContext<Database>(opt => opt.UseSqlServer(ConnectionString));
            services.AddTransient<DatabaseInitializer>();
            services.AddSingleton<DatabaseManager>();

            return services;
        }
    }
}
