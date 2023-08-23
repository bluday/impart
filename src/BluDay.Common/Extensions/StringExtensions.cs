using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;

namespace BluDay.Common.Extensions
{
    public static class StringExtensions
    {
        public static string BluReplace(this string source, object oldValue, object newValue)
        {
            return source?.Replace(
                oldValue: oldValue?.ToString(),
                newValue: newValue?.ToString()
            );
        }

        public static string BluReplaceByCollection<T>(
            this string          source,
                 IEnumerable<T>  items,
                 Func<T, object> selector)
        {
            return source.BluReplaceByCollection(
                items:    items,
                selector: (item, count) => selector(item)
            );
        }

        public static string BluReplaceByCollection<T>(
            this string               source,
                 IEnumerable<T>       items,
                 Func<T, int, object> selector)
        {
            if (source is null || items is null || selector is null)
            {
                return null;
            }

            int count = 0;

            foreach (T item in items)
            {
                source = source.BluReplace(
                    oldValue: item,
                    newValue: selector(item, count++)
                );
            }

            return source;
        }

        public static string BluReplaceToIndexes<T>(this string source, IEnumerable<T> items)
        {
            if (source is null || items is null)
            {
                return null;
            }

            int count = 0;

            foreach (T item in items)
            {
                source = source.BluReplace(item, count++);
            }

            return source;
        }

        public static bool BluIsEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool BluIsWhitespace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static string BluFormat(this string source, params object[] values)
        {
            if (source.BluIsWhitespace() || values is null)
            {
                return source;
            }

            return string.Format(source, values);
        }

        public static string BluOr(this string source, string value)
        {
            return source.BluIsWhitespace() ? value : source;
        }

        public static string BluRemove(this string source, string value)
        {
            return source?.Replace(value, string.Empty);
        }

        public static Uri BluToUri(this string source, UriKind kind = UriKind.RelativeOrAbsolute)
        {
            if (source.BluIsWhitespace())
            {
                return null;
            }

            return new Uri(source, kind);
        }

        public static BitmapImage BluToBitmapImage(this string source)
        {
            if (source.BluIsWhitespace())
            {
                return null;
            }

            return new BitmapImage(source.BluToUri());
        }
    }
}