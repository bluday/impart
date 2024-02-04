namespace BluDay.Common.Attributes;

public sealed class CommandLineArgAttribute : Attribute
{
    public ArgActionType ActionType { get; }

    public bool Required { get; }

    public object? Constant { get; }

    public string Arg { get; }
    
    public string? Description { get; }

    public IReadOnlyList<string> Identifiers { get; }

    public CommandLineArgAttribute(
        string[]      identifiers,
        ArgActionType actionType  = ArgActionType.ParseArg,
        object?       constant    = null,
        bool          required    = false,
        string?       description = null)
    {
        ActionType = actionType;

        Required = required;

        Constant = constant;

        Arg = identifiers[0];

        Description = description;

        Identifiers = identifiers ?? Array.Empty<string>();
    }
}