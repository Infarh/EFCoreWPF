using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreWPF
{
    static class Program
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
               .UseContentRoot(Environment.CurrentDirectory)
               .ConfigureAppConfiguration((host, cfg) => 
                    cfg.SetBasePath(Environment.CurrentDirectory)
                       .AddJsonFile("appsettings.json", true, true))
               .ConfigureServices(App.ConfigureServices);
    }
}
