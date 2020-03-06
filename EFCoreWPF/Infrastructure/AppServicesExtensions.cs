using EFCoreWPF.Infrastructure.Interfaces;
using EFCoreWPF.Infrastructure.Services;
using EFCoreWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.Infrastructure
{
    internal static class AppServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserDialogService, UserDialogService>();

            services.AddSingleton<MainWindowViewModel>();

            return services;
        }
    }
}
