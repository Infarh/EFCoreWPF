using System.Windows;
using System.Windows.Input;
using EFCoreWPF.Infrastructure;
using EFCoreWPF.Infrastructure.Interfaces;
using EFCoreWPF.Services.Interfaces;
using EFCoreWPF.ViewModels.Base;

namespace EFCoreWPF.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IUserDialogService _UserDialog;
        private readonly IStudentsManager _StudentsManager;

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Тестовый проект для БД";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region Команды

        #region Command ExitCommand - Выход

        /// <summary>Выход</summary>
        public ICommand ExitCommand { get; }

        /// <summary>Проверка возможности выполнения - Выход</summary>
        private static bool CanExitCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Выход</summary>
        private static void OnExitCommandExecuted(object p) => Application.Current.Shutdown(p as int? ?? 0);

        #endregion

        #region Command AboutProgramCommand - О программе

        /// <summary>О программе</summary>
        public ICommand AboutProgramCommand { get; }

        #endregion

        #endregion

        public MainWindowViewModel(IUserDialogService UserDialog, IStudentsManager StudentsManager)
        {
            _UserDialog = UserDialog;
            _StudentsManager = StudentsManager;

            #region Команды

            ExitCommand = new LambdaCommand(OnExitCommandExecuted, CanExitCommandExecute);
            AboutProgramCommand = new LambdaCommand(_UserDialog.AboutProgram);

            #endregion
        }
    }
}
