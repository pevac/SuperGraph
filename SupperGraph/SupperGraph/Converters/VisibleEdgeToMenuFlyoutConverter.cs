using System;
using Windows.UI.Xaml.Data;

namespace SupperGraph.Converters
{
    public class VisibleEdgeToMenuFlyoutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var arg = (bool)value;
            var visibility = arg == true ? "Visible" : "Collapsed";
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
