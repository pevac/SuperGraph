using System;
using Windows.UI.Xaml.Data;

namespace SupperGraph.Converters
{
    public class VisibleEdgeFromMenuFlyout : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var arg = (bool)value;
            var visibility = arg == false ? "Visible" : "Collapsed";
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
