using System.Reflection;

namespace BluDay.Common.Helpers;

public static class ArgumentsParser
{
    public static TOptions Parse<TOptions>(string args) where TOptions : new()
    {
        return Parse<TOptions>(args.Split(Constants.Whitespace));
    }

    public static TOptions Parse<TOptions>(params string[] args) where TOptions : new()
    {
        var optionsType = typeof(TOptions);

        object? options = Activator.CreateInstance(optionsType);

        var flags = BindingFlags.Instance
            | BindingFlags.DeclaredOnly
            | BindingFlags.Public;

        foreach (PropertyInfo property in optionsType.GetProperties(flags))
        {
            var attribute = property.GetCustomAttribute<CommandLineArgAttribute>();

            if (attribute is null) continue;

            for (int index = 0; index < args.Length; index++)
            {
                string argument = args[index];


            }
        }

        return (TOptions)options!;
    }
}