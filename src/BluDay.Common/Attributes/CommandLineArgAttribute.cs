namespace BluDay.Common.Attributes;

public sealed class CommandLineArgAttribute : Attribute
{
    private readonly List<string> _identifiers;

    public ArgActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string MainIdentifier { get; }
    
    public string? Description { get; init; }

    public IReadOnlyList<string> Identifiers => _identifiers.AsReadOnly();

    public CommandLineArgAttribute(string[] identifiers)
    {
        if (identifiers is null || identifiers.Length < 1)
        {
            throw new ArgumentException("Identifiers collection must contain at least one element.");
        }

        _identifiers = new(identifiers);

        MainIdentifier = _identifiers[0];
    }
}