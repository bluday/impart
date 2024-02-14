namespace BluDay.Common.Parsing;

public sealed class ArgInfo
{
    public ArgActionType ActionType { get; init; }

    public bool Required { get; init; }

    public object? Constant { get; init; }

    public string MainIdentifier { get; }

    public string? Description { get; init; }

    public Guid Id { get; } = Guid.NewGuid();

    public IReadOnlyList<string> Identifiers { get; }

    public ArgInfo(string[] identifiers)
    {
        if (identifiers is null || identifiers.Length < 1)
        {
            throw new ArgumentException("Identifiers collection must contain at least one element.");
        }

        MainIdentifier = identifiers[0];

        Identifiers = identifiers.AsReadOnly();
    }
}