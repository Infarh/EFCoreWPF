using System;
using System.Collections.Generic;
using System.Text;
using EFCoreWPF.Services.Interfaces;
using EFCoreWPF.Services.Stores.EF;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddStudentServices(this IServiceCollection services)
        {
            services.AddSingleton<IStudentStore, StudentsStore>();
            services.AddSingleton<ICoursesStore, CoursesStore>();

            services.AddSingleton<IStudentsManager, StudentsesManager>();

            return services;
        }
    }
}
