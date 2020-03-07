using System.Windows;
using EFCoreWPF.Infrastructure.Interfaces;
using EFCoreWPF.Views;

namespace EFCoreWPF.Infrastructure.Services
{
    internal class UserDialogService : IUserDialogService
    {
        public void AboutProgram() => new AboutWindow { Owner = Application.Current.MainWindow }.ShowDialog();
    }
}
