using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using SupperGraph.Models;

namespace SupperGraph.Controls
{
    public class FlyoutAction : UserControl, IAction
    {

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(FlyoutAction), new PropertyMetadata(default(ICommand)));


        public object Execute(object sender, object parameter)
        {
            FrameworkElement senderElement = sender as FrameworkElement;

            var node = senderElement?.DataContext as Node;
            if (this.Command == null)
                return (object)false;
            if (!this.Command.CanExecute(node))
                return (object)false;
            this.Command.Execute(node);
            return (object)true;
        }

    }
}
