using System.Reflection;

namespace BluDay.Common.Parsing;

public static class ArgsParser
{
    public readonly static BindingFlags PropertyBindingFlags;

    static ArgsParser()
    {
        PropertyBindingFlags = BindingFlags.Instance
            | BindingFlags.DeclaredOnly
            | BindingFlags.Public;
    }

    public static TArgs? Parse<TArgs>(string args) where TArgs : IArgs, new()
    {
        // ArgumentException.ThrowIfNullOrWhiteSpace(args);

        return Parse<TArgs>(values: args.Split(Constants.Whitespace));
    }

    public static TArgs? Parse<TArgs>(params string[] values) where TArgs : IArgs, new()
    {
        if (values.Length < 1)
        {
            throw new ArgumentException("Argument count is less than one.");
        }

        TArgs? args = Activator.CreateInstance<TArgs>();

        PropertyInfo[] properties = typeof(TArgs).GetProperties();

        foreach (var property in properties)
        {
            IArgInfo? argInfo = property.GetCustomAttribute<ArgAttribute>();

            if (argInfo is null) continue;

            // TODO: Find a good and concise way to parse all args properly.
        }

        return args;
    }
}