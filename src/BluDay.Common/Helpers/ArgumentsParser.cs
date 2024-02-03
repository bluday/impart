namespace BluDay.Common.Helpers;

public static class ArgumentsParser
{
    public static TOptions Parse<TOptions>(string args) where TOptions : new()
    {
        return Parse<TOptions>(args.Split(Constants.Whitespace));
    }

    public static TOptions Parse<TOptions>(string[] args) where TOptions : new()
    {
        object? options = Activator.CreateInstance(typeof(TOptions));

        // TODO: Reflection-related stuff here.

        return (TOptions)options!;
    }
}