using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;
using Microsoft.Xaml.Interactivity;
using SupperGraph.Models;

namespace SupperGraph.Controls
{
    public class LineManipulationDeltaAction:DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            var arg = (ManipulationDeltaRoutedEventArgs) parameter;
            var line = (Line) arg.OriginalSource;
            var edge = (Edge) line.DataContext;

            edge.LeftNode.X = edge.LeftNode.X + arg.Delta.Translation.X;
            edge.LeftNode.Y = edge.LeftNode.Y + arg.Delta.Translation.Y;

            edge.RightNode.X = edge.RightNode.X + arg.Delta.Translation.X;
            edge.RightNode.Y = edge.RightNode.Y + arg.Delta.Translation.Y;
            return (object) true;
        }
    }
}
