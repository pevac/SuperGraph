using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using SupperGraph.Models;

namespace SupperGraph.Converters
{
    public class MouseButtonEventArgsToPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var args = (TappedRoutedEventArgs)value;
            var element = (FrameworkElement)parameter;
            var point = args.GetPosition(element);

            point.X = Math.Round(point.X, 0);
            point.Y = Math.Round(point.Y, 0);
            if ((point.X % 10) < 2 & (point.Y % 10) < 2)
            {
                point.Y = point.Y - point.Y%10;
                point.X = point.X - point.X%10;
            }
            else if ((point.X % 10) > 8 & (point.Y % 10) > 8)
            {
                point.Y = point.Y - point.Y%10 + 10;
                point.X = point.X - point.X%10 + 10;
            }
            else if ((point.X % 10) < 2 & (point.Y % 10) > 8)
            {
                point.Y = point.Y - point.Y % 10 + 10;
                point.X = point.X - point.X % 10;
            }
            else if ((point.X % 10) > 8 & (point.Y % 10) <2)
            {
                point.Y = point.Y - point.Y % 10;
                point.X = point.X - point.X % 10 + 10;
            }

            return new Node(point);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
