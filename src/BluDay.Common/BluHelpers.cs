using BluDay.Common.Extensions;
using Windows.UI.Xaml;

namespace BluDay.Common
{
    public static class BluHelper
    {
        public static bool IsLessThan(int x, int y)
        {
            return x < y;
        }

        public static bool IsLessThan(double x, double y)
        {
            return x < y;
        }

        public static bool IsLessEqualsThan(int x, int y)
        {
            return x <= y;
        }

        public static bool IsLessEqualsThan(double x, double y)
        {
            return x <= y;
        }

        public static bool IsNull(object value)
        {
            return value is null;
        }

        public static bool Negate(bool value)
        {
            return !value;
        }

        public static bool NotWhitespace(string value)
        {
            return !value.BluIsWhitespace();
        }

        public static bool AlignmentToBoolean(HorizontalAlignment value)
        {
            return value is HorizontalAlignment.Left;
        }
    }
}