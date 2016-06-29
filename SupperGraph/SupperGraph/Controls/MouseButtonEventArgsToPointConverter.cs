﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using SupperGraph.Models;

namespace SupperGraph.Controls
{
    public class MouseButtonEventArgsToPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var args = (TappedRoutedEventArgs)value;
            var element = (FrameworkElement)parameter;
            var point = args.GetPosition(element);
            return new Node(point);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
