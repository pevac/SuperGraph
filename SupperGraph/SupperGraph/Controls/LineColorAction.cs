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
            if (sender is Line)
            {
                var line = (Line)sender;
                var stroke = line.Stroke as SolidColorBrush;
                if (stroke == null)
                {
                    return (object)true;
                }
                var color = stroke.Color;

                var redBrush = new SolidColorBrush { Color = Colors.Red };

                var blackBrush = new SolidColorBrush { Color = Colors.Black };

                if (color == redBrush.Color)
                {
                    line.StrokeThickness = 2;
                    line.Stroke = blackBrush;
                }
                else
                {
                    line.StrokeThickness = 3;
                    line.Stroke = redBrush;
                } 
            }
            else if (sender is Path)
            {
                var path = (Path)sender;
                var stroke = path.Stroke as SolidColorBrush;
                if (stroke == null)
                {
                    return (object) true;
                }
                var color = stroke.Color;

                var redBrush = new SolidColorBrush { Color = Colors.Red };

                var blackBrush = new SolidColorBrush { Color = Colors.Black };

                if (color == redBrush.Color)
                {
                    path.StrokeThickness = 1;
                    path.Stroke = blackBrush;
                }
                else
                {
                    path.StrokeThickness = 2;
                    path.Stroke = redBrush;
                } 
            }
            else
            {
                throw new ArgumentException("Wrong item type!", nameof(sender));
            }



            
            return (object) true;
        }
    }
}
