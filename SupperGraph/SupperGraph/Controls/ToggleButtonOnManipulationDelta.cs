using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace SupperGraph.Controls
{
    public class ToggleButtonOnManipulationDelta : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {

            var arg = (ManipulationDeltaRoutedEventArgs)value;

            var togglebutton = (ToggleButton)arg.OriginalSource;
            var node = (Node)togglebutton.DataContext;

            node.X = node.X + arg.Delta.Translation.X;
            node.Y = node.Y + arg.Delta.Translation.Y;

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
