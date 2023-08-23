using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BluDay.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void BluAddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            if (source is null || items is null)
            {
                return;
            }

            foreach (T item in items)
            {
                source.Add(item);
            }
        }

        public static T BluAddAndReturn<T>(this ICollection<T> source, T item)
        {
            if (source is null) return default;

            source.Add(item);

            return item;
        }

        public static T BluNextOrPrevious<T>(this Collection<T> source, T item)
        {
            if (source is null || source.Count == 0)
            {
                return default;
            }

            int index = source.IndexOf(item),
                size  = source.Count - 1;

            index = index < size ? ++index : --index;

            return source[index];
        }

        public static void BluReset<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            if (source is null) return;

            source.Clear();
            source.BluAddRange(items);
        }

        public static bool BluTryAdd<T>(this Collection<T> source, T item)
        {
            if (source is null || source?.Contains(item) is true)
            {
                return false;
            }

            source?.Add(item);

            return true;
        }
    }
}