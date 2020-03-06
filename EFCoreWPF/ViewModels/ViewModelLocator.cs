using System;
using System.Collections.Generic;
using System.Text;
using EFCoreWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
