using System;
using System.Collections.Generic;
using System.Text;
using EFCoreWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
