using System;

namespace BluDay.Common.UI.Xaml.Converters
{
    public sealed class NullToBooleanConverter : Windows.UI.Xaml.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !(value is null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return !(value is null);
        }
    }
}