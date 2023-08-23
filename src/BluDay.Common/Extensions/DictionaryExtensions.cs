using System.Collections.Generic;

namespace BluDay.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static void BluAddRange<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
                 Dictionary<TKey, TValue> other)
        {
            if (source is null || other is null)
            {
                return;
            }

            foreach (var (key, value) in other)
            {
                source.Add(key, value);
            }
        }

        public static int BluAddValueWithMultipleKeys<TKey, TValue>(
            this   Dictionary<TKey, TValue> source,
                   TValue                   value,
            params TKey[]                   keys)
        {
            if (source is null) return -1;

            int count = 0;

            foreach (var key in keys)
            {
                if (source.TryAdd(key, value))
                {
                    count++;
                }
            }

            return count;
        }

        public static Dictionary<TKey, TValue> BluAsConcreteMap<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> source)
        {
            return source as Dictionary<TKey, TValue>;
        }

        public static int BluRemoveValueByKeys<TKey, TValue>(
            this   Dictionary<TKey, TValue> source,
            params TKey[]                   keys)
        {
            if (source is null) return -1;

            int count = 0;

            foreach (TKey key in keys)
            {
                if (source.Remove(key))
                {
                    count++;
                }
            }

            return count;
        }
    }
}