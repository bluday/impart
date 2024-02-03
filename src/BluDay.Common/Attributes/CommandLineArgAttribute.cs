namespace BluDay.Common.Attributes;

public sealed class CommandLineArgAttribute : Attribute
{
    public bool Required { get; init; }

    public int ValueCount { get; init; }

    public string Arg { get; }
    
    public string? Description { get; init; }

    public IReadOnlyList<string> Aliases { get; init; }

    public CommandLineArgAttribute(string arg, params string[] aliases)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(arg);

        Arg = arg;

        Aliases = aliases ?? Array.Empty<string>();
    }
}