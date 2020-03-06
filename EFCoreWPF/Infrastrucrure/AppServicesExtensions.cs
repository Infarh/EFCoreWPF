using System;
using System.Collections.Generic;
using System.Text;
using EFCoreWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.Infrastrucrure
{
    static class AppServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

            return services;
        }
    }
}
