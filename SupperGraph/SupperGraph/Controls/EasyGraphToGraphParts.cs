using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using MyToolkit.Collections;

namespace SupperGraph.Controls
{
    public class EasyGraphToGraphParts : IValueConverter
    {
        private MtObservableCollection<object> _graphParts;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var graph = (Graph)value;

            _graphParts = new MtObservableCollection<object>();
            _graphParts.AddRange(graph.Nodes);
            _graphParts.AddRange(graph.Edges);

            return _graphParts;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
