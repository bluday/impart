using System;
using System.Collections.Generic;

namespace BluDay.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static int BluAggregateCount<T>(this IEnumerable<T> source, Func<T, int> selector)
            where T : class
        {
            if (source is null) return 0;

            int count = 0;

            foreach (T item in source)
            {
                count += selector(item);
            }

            return count;
        }

        public static bool BluAll<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source is null || predicate is null)
            {
                return false;
            }

            foreach (T item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static T BluAtIndex<T>(this IEnumerable<T> source, int index)
        {
            if (source is null) return default;

            T[] items = source.BluSelect(item => item);

            if (items.Length == 0 || index >= items.Length)
            {
                return default;
            }

            return items[index];
        }

        public static bool BluContains<T>(this IEnumerable<T> source, T target)
        {
            if (source is null) return false;

            foreach (T item in source)
            {
                if (Equals(target, item))
                {
                    return true;
                }
            }

            return false;
        }

        public static string BluCreateUniqueKey<T>(
            this IEnumerable<T>  source,
                 Func<T, string> selector,
                 Predicate<T>    predicate = null,
                 string          baseName  = null
        )
            where T : class
        {
            if (source is null) return null;

            var items = new List<T>(source).ToArray();

            baseName = baseName ?? typeof(T).Name;

            string key = null;

            int index = 0, length = items.Length;

            for (int i = 0; i < length; i++)
            {
                if (!(predicate is null) && !predicate(items[i]))
                {
                    continue;
                }

                key = baseName + index;

                for (int j = i; j < length; j++)
                {
                    if (key == selector(items[j]))
                    {
                        index++;

                        break;
                    }

                    if (j == length - 1)
                    {
                        i = length;
                    }
                }
            }

            return key;
        }

        public static T BluFirst<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source is null || predicate is null)
            {
                return default;
            }

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default;
        }

        public static bool BluHas<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source is null || predicate is null)
            {
                return default;
            }

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static T BluLast<T>(this IEnumerable<T> source)
        {
            if (source is null) return default;

            T[] items = source.BluToArray();

            return items[items.Length - 1];
        }

        public static T BluLast<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source is null || predicate is null)
            {
                return default;
            }

            T[] items = source.BluWhere(predicate);

            return items[items.Length - 1];
        }

        public static T2[] BluSelect<T1, T2>(this IEnumerable<T1> source, Func<T1, T2> selector)
        {
            return source.BluSelect((item, index) => selector(item));
        }

        public static T2[] BluSelect<T1, T2>(this IEnumerable<T1> source, Func<T1, int, T2> selector)
        {
            if (source is null || selector is null)
            {
                return new T2[] { };
            }

            var values = new List<T2>();

            int index = 0;

            foreach (T1 item in source)
            {
                values.Add(selector(item, index));
            }

            return values.ToArray();
        }

        public static T[] BluToArray<T>(this IEnumerable<T> source)
        {
            if (source is null) return default;

            var items = new List<T>();

            foreach (T item in source)
            {
                items.Add(item);
            }

            return items.ToArray();
        }

        public static string BluToPrintableValue<T>(this IEnumerable<T> source, int maxEntryLength = -1)
        {
            if (source is null) return null;

            string[] values = source.BluSelect(item => item.ToString());

            var entries = string.Empty;

            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i];

                if (maxEntryLength >= 0)
                {
                    value = value.Substring(0, maxEntryLength);

                    value += BluConstants.ASCII_ELLIPSES;
                }

                entries += BluConstants.TAB_CHAR;
                entries += value;

                if (i < values.Length - 1)
                {
                    entries += BluConstants.COMMA_CHAR;
                    entries += BluConstants.NEW_LINE_CHAR;
                }
            }

            return BluConstants.PRINTABLE_LIST_OUTER_FORMAT.BluFormat(entries);
        }

        public static T[] BluWhere<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source is null)
            {
                return new T[] { };
            }

            var items = new List<T>();

            foreach (T item in source)
            {
                if (predicate is null || predicate(item))
                {
                    items.Add(item);
                }
            }

            return items.ToArray();
        }
    }
}