using System;
using System.Windows;
using EFCoreWPF.Data;
using EFCoreWPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreWPF
{
    public partial class App
    {
        private static IHost __Host;

        public static IHost Host => __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            await host.Services.GetRequiredService<DatabaseInitializer>().InitializeAsync();

            base.OnStartup(e);

            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            __Host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddDbContext<Database>(opt => 
                opt.UseSqlServer(host.Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<DatabaseInitializer>();

            services.AddSingleton<MainWindowViewModel>();
        }
    }
}
