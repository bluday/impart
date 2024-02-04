namespace BluDay.Common.Attributes;

public sealed class CommandLineArgumentAttribute : Attribute
{
    public ArgumentActionType ActionType { get; }

    public bool Required { get; }

    public object? Constant { get; }

    public string Argument { get; }
    
    public string? Description { get; }

    public IReadOnlyList<string> Identifiers { get; }

    public CommandLineArgumentAttribute(
        string[]           identifiers,
        ArgumentActionType actionType  = ArgumentActionType.ParseArg,
        object?            constant    = null,
        bool               required    = false,
        string?            description = null)
    {
        ActionType = actionType;

        Required = required;

        Constant = constant;

        Argument = identifiers[0];

        Description = description;

        Identifiers = identifiers ?? Array.Empty<string>();
    }
}