using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace TailBlazer.LogViewer.Infrastucture
{
    public class CheckedToLengthConverter : 
        //MarkupExtension, 
        IValueConverter
    {
        public GridLength TrueValue { get; set; }
        public GridLength FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return BindingOperations.DoNothing;
        }

        //#region Overrides of MarkupExtension

        //public override object ProvideValue(IServiceProvider serviceProvider)
        //{
        //    return this;
        //}

        //#endregion
    }
}