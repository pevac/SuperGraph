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
    public class ToggleButtonManipulationDeltaAction:DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            var arg = parameter as ManipulationDeltaRoutedEventArgs;
            if (arg == null) return (object)true;
            var togglebutton = (ToggleButton)arg.OriginalSource;
            var node = (Node)togglebutton.DataContext;

            node.X = node.X + arg.Delta.Translation.X;
            node.Y = node.Y + arg.Delta.Translation.Y;
            node.X = Math.Round(node.X, 0);
            node.Y = Math.Round(node.Y, 0);
            if ((node.X % 10) < 2 & (node.Y % 10) < 2)
            {
                node.Y = node.Y - node.Y % 10;
                node.X = node.X - node.X % 10;
            }
            else if ((node.X % 10) > 8 & (node.Y % 10) > 8)
            {
                node.Y = node.Y - node.Y % 10 + 10;
                node.X = node.X - node.X % 10 + 10;
            }
            else if ((node.X % 10) < 2 & (node.Y % 10) > 8)
            {
                node.Y = node.Y - node.Y % 10 + 10;
                node.X = node.X - node.X % 10;
            }
            else if ((node.X % 10) > 8 & (node.Y % 10) < 2)
            {
                node.Y = node.Y - node.Y % 10;
                node.X = node.X - node.X % 10 + 10;
            }

            return (object)true;
        }
    }
}
