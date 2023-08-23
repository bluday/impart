using System;
using System.Globalization;

namespace BluDay.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime Now => DateTime.Now;

        public static DateTimeFormatInfo InstalledFormatInfo
        {
            get => CultureInfo.InstalledUICulture.DateTimeFormat;
        }

        public static string GetContextualFormat(this DateTime source)
        {
            if (source.Year == Now.Year)
            {
                if (source.DayOfYear == Now.DayOfYear)
                {
                    return InstalledFormatInfo.ShortTimePattern;
                }

                return DateTimeFormatInfo.InvariantInfo.MonthDayPattern;
            }

            return InstalledFormatInfo.ShortDatePattern;
        }

        public static string ToContextualOrDefaultFormat(this DateTime source, string format)
        {
            if (format is BluConstants.Contextual)
            {
                format = source.GetContextualFormat();
            }

            return source.ToString(format);
        }

        public static string ToString(this DateTime? source, string format)
        {
            return source?.ToString(format);
        }
    }
}