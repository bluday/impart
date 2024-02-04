using System.Reflection;

namespace BluDay.Common.Helpers;

public static class ArgumentsParser
{
    public static BindingFlags PropertyBindingFlags { get; }

    static ArgumentsParser()
    {
        PropertyBindingFlags = BindingFlags.Instance
            | BindingFlags.DeclaredOnly
            | BindingFlags.Public;
    }

    public static TOptions Parse<TOptions>(string args) where TOptions : new()
    {
        return Parse<TOptions>(args: args.Split(Constants.Whitespace));
    }

    public static TOptions Parse<TOptions>(params string[] args) where TOptions : new()
    {
        var optionsType = typeof(TOptions);

        object? options = Activator.CreateInstance(optionsType);

        PropertyInfo[] properties = optionsType.GetProperties(PropertyBindingFlags);

        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<CommandLineArgumentAttribute>();

            if (attribute is null) continue;

            for (int index = 0; index < args.Length; index++)
            {
                // ( 0 _ o )
            }
        }

        return (TOptions)options!;
    }
}