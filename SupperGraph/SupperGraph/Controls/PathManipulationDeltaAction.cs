using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;
using Microsoft.Xaml.Interactivity;
using SupperGraph.Models;

namespace SupperGraph.Controls
{
    public class PathManipulationDeltaAction : DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            var arg = parameter as ManipulationDeltaRoutedEventArgs;
            if (arg == null) return (object) true;
            var path = (Path)arg.OriginalSource;
            var edge = (Edge) path.DataContext;

            edge.LeftNode.X = edge.LeftNode.X + arg.Delta.Translation.X;
            edge.LeftNode.Y = edge.LeftNode.Y + arg.Delta.Translation.Y;

            return (object) true;
        }
    }
}
