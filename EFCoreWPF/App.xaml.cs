using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using EFCoreWPF.Data;
using EFCoreWPF.Infrastructure;
using EFCoreWPF.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreWPF
{
    public partial class App
    {
        private static bool __IsDesignTime = true;
        public static bool IsDesignTime => __IsDesignTime;


        private static IHost __Host;

        public static IHost Host => __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            __IsDesignTime = false;
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
            services.AddDatabaseServices(host.Configuration.GetConnectionString("DefaultConnection"));
            services.AddStudentServices();
            services.AddAppServices();
        }

        public static string GetCurrentDirectory() => IsDesignTime ? Path.GetDirectoryName(GetSourceCodePath()) : Environment.CurrentDirectory;

        public static string GetSourceCodePath([CallerFilePath] string path = null) => path;
    }
}
