using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Microsoft.Xaml.Interactivity;

namespace SupperGraph.Controls
{
    public class AddGridToBackground : DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            var grid = sender as Grid;
            if (grid == null)
            {
                return null;
            }
            var arg = grid.Children;
            Canvas mainCanvas = new Canvas();
            foreach (var element in arg)
            {
                if (element is Canvas)
                {
                    mainCanvas = (Canvas)element;
                }
            }
            var w = mainCanvas.ActualWidth;
            var h = mainCanvas.ActualHeight;
            mainCanvas.Children.Clear();

            for (var x = 100; x < w; x += 100)
            {
                mainCanvas.Children.Add(AddLineToBackground(x, 0, x, h, 0.5));
            }
            for (var y = 100; y < h; y += 100)
            {
                mainCanvas.Children.Add(AddLineToBackground(0, y, w, y, 0.5));
            }
            for (var x = 10; x < w; x += 10)
            {
                mainCanvas.Children.Add(AddLineToBackground(x, 0, x, h, 0.2));
            }
            for (var y = 10; y < h; y += 10)
            {
                mainCanvas.Children.Add(AddLineToBackground(0, y, w, y, 0.2));
            }
            return null;
        }

        Line AddLineToBackground(double x1, double y1, double x2, double y2, double thick)
        {
            var line = new Line()
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                IsTapEnabled = false,
                Stroke = new SolidColorBrush(Windows.UI.Colors.Black),
                StrokeThickness = thick,
            };
            return line;
        }
    }
}
