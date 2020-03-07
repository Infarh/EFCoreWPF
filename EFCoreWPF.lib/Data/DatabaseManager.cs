using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.Data
{
    public class DatabaseManager
    {
        private readonly IServiceProvider _Services;
        private readonly Lazy<Database> _Database;

        public Database SingletonContext => _Database.Value;

        public DatabaseManager(IServiceProvider Services)
        {
            _Services = Services;
            _Database = new Lazy<Database>(GetContext, LazyThreadSafetyMode.PublicationOnly);
        }

        public Database GetContext() => _Services.GetRequiredService<Database>();
    }
}
