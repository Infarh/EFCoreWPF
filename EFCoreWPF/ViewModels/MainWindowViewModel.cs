using System;
using System.Collections.Generic;
using System.Text;
using EFCoreWPF.ViewModels.Base;

namespace EFCoreWPF.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Тестовый проект для БД";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion
    }
}
