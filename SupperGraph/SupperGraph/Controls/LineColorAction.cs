using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Microsoft.Xaml.Interactivity;

namespace SupperGraph.Controls
{
    public class LineColorAction:DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            var line = (Line) sender;
            var stroke = (SolidColorBrush)line.Stroke;
            var color = stroke.Color;

            var redBrush = new SolidColorBrush {Color = Colors.Red};

            var blackBrush = new SolidColorBrush {Color = Colors.Black};

            if (color == redBrush.Color)
            {
                line.StrokeThickness = 1;
                line.Stroke = blackBrush;
            }
            else
            {
                line.StrokeThickness = 2;
                line.Stroke = redBrush;
            }



            
            return (object) true;
        }
    }
}
