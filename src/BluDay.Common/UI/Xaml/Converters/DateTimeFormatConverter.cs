using BluDay.Common.Extensions;
using System;

namespace BluDay.Common.UI.Xaml.Converters
{
    public sealed class DateTimeFormatConverter : Windows.UI.Xaml.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dateTime = (DateTime)value;

            var format = parameter as string;

            if (format.BluIsWhitespace())
            {
                return null;
            }

            return dateTime.ToContextualOrDefaultFormat(format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}