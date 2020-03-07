using System;
using EFCoreWPF.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreWPF.ViewModels
{
    internal class ViewModelLocator : ViewModel
    {
        private Exception _Exception;
        public Exception Exception { get => _Exception; private set => Set(ref _Exception, value); }

        public MainWindowViewModel MainWindowModel
        {
            get
            {
                try
                {
                    return App.Host.Services.GetRequiredService<MainWindowViewModel>();
                }
                catch (Exception e)
                {
                    Exception = e;
                    throw;
                }
            }
        }
    }
}
