namespace BluDay.Common.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] BluAsKnownArray<T>(this System.Array source)
        {
            if (source is null) return default;

            var items = new T[source.Length];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = (T)source.GetValue(i);
            }

            return items;
        }
    }
}