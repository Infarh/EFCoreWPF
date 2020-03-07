using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using EFCoreWPF.Service;
using Microsoft.Xaml.Behaviors;

namespace EFCoreWPF.Infrastructure.Behaviours
{
    class CloseWindowOnClick : Behavior<ButtonBase>
    {
        protected override void OnAttached() => AssociatedObject.Click += OnClick;

        protected override void OnDetaching() => AssociatedObject.Click -= OnClick;

        private static void OnClick(object Sender, RoutedEventArgs E) => 
            ((ButtonBase)Sender).GetLogicalRoot<Window>()?.Close();
    }
}
