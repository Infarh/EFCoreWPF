using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace EFCoreWPF.Service
{
    internal static class TreeHalpersExtensions
    {
        public static IEnumerable<DependencyObject> GetVisualParents(this DependencyObject obj)
        {
            var item = VisualTreeHelper.GetParent(obj);
            while (item != null)
            {
                yield return item;
                item = VisualTreeHelper.GetParent(item);
            }
        }

        public static IEnumerable<DependencyObject> GetLogicalParents(this DependencyObject obj)
        {
            var item = VisualTreeHelper.GetParent(obj);
            while (item != null)
            {
                yield return item;
                item = LogicalTreeHelper.GetParent(item);
            }
        }

        public static T GetVisualRoot<T>(this DependencyObject obj) where T : DependencyObject =>
            obj.GetVisualParents().OfType<T>().Last(); 

        public static T GetLogicalRoot<T>(this DependencyObject obj) where T : DependencyObject =>
            obj.GetLogicalParents().OfType<T>().Last();
    }
}
