namespace BluDay.Common.Extensions
{
    public static class CharExtensions
    {
        public static char ToLower(this char source)
        {
            return char.ToLower(source);
        }

        public static string Join(this char source, params object[] values)
        {
            return string.Join(source, values);
        }
    }
}
