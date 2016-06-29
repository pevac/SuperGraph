﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SupperGraph.Controls
{
    public class DeltaAddNode : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            const double delta = 15;
            var valuenode = (double)value;
            var node = valuenode - delta;
            return node;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
