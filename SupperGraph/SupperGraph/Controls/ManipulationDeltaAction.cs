using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Microsoft.Xaml.Interactivity;
using SupperGraph.Models;

namespace SupperGraph.Controls
{

    public class ManipulationDeltaAction : DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            var arg = (ManipulationDeltaRoutedEventArgs)parameter;

            var togglebutton = (ToggleButton)arg.OriginalSource;
            var node = (Node)togglebutton.DataContext;

            node.X = node.X + arg.Delta.Translation.X;
            node.Y = node.Y + arg.Delta.Translation.Y;
            return null;
        }
    }
}
