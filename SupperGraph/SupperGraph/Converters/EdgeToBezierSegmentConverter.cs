using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using SupperGraph.Models;

namespace SupperGraph.Converters
{
    public class EdgeToBezierSegmentConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var point = (Node) value;
            return $"M {point.X},{point.Y-15} C{point.X},{point.Y - 15} {point.X+28},{point.Y - 25} {point.X + 30},{point.Y} C {point.X + 30},{point.Y} {point.X +28},{point.Y + 25} {point.X},{point.Y+15}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
