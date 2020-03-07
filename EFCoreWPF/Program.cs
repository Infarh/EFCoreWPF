using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EFCoreWPF
{
    internal static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .UseContentRoot(App.GetCurrentDirectory())
               .ConfigureAppConfiguration((host, cfg) => 
                    cfg.SetBasePath(App.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", true, true))
               .ConfigureServices(App.ConfigureServices);
    }
}
