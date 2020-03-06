using System.Windows;
using EFCoreWPF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreWPF
{
    public partial class App
    {
        private IHost _Host;

        protected override async void OnStartup(StartupEventArgs e)
        {
            _Host = Program.CreateHostBuilder(e.Args).Build();

            var db_initializer = _Host.Services.GetRequiredService<DatabaseInitializer>();
            await db_initializer.InitializeAsync();

            base.OnStartup(e);

            await _Host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            await _Host.StopAsync().ConfigureAwait(false);
            _Host.Dispose();
            _Host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddDbContext<Database>(opt => 
                opt.UseSqlServer(host.Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DatabaseInitializer>();
        }
    }
}
