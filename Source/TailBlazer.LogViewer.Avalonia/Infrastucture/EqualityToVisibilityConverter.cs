using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using Avalonia.Data.Converters;

namespace TailBlazer.LogViewer.Infrastucture
{
    public class EqualityToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.Equals(parameter)) return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
