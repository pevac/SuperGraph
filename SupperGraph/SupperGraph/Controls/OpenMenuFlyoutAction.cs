using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Microsoft.Xaml.Interactivity;

namespace SupperGraph.Controls
{
    public class OpenMenuFlyoutAction : DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);

            var eventArgs = parameter as RightTappedRoutedEventArgs;
            if (eventArgs == null)
            {
                return null;
            }

            var element = eventArgs.OriginalSource as FrameworkElement;
            if (element == null)
            {
                HoldedObject = element.DataContext;
            }

            return null;
        }

        public static object HoldedObject { get; set; }
    }
}
