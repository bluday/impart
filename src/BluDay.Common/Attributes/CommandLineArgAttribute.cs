namespace BluDay.Common.Attributes;

public sealed class CommandLineArgAttribute : Attribute
{
    public ArgInfo ArgInfo { get; }

    public CommandLineArgAttribute(
        string[]      identifiers,
        ArgActionType actionType  = ArgActionType.ParseArg,
        bool          required    = false,
        object?       constant    = null,
        string?       description = null)
    {
        ArgInfo = new(identifiers)
        {
            ActionType  = actionType,
            Required    = required,
            Constant    = constant,
            Description = description
        };
    }
}