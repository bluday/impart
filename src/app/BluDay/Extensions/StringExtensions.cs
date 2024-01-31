namespace BluDay.Common.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string source)
    {
        return string.IsNullOrWhiteSpace(source);
    }

    public static bool IsNullOrEmpty(this string source)
    {
        return string.IsNullOrEmpty(source);
    }

    public static string? NotWhiteSpaceOrDefault(this string source, string? defaultValue = null)
    {
        return string.IsNullOrWhiteSpace(source) ? defaultValue : source;
    }
}