namespace BluDay.Common.Attributes;

public sealed class ArgAttribute : Attribute, IArgInfo
{
    private object? _constant;

    private readonly List<string> _identifiers;

    public ArgActionType ActionType { get; init; }

    public object? Constant
    {
        get => _constant;
        init
        {
            if (value is not null && value.GetType() != ValueType)
            {
                throw new ArgumentException($"Constant value must be of type {ValueType}.");
            }

            _constant = value;
        }
    }

    public string MainIdentifier { get; }

    public string? Description { get; init; }

    public Guid Id { get; }

    public Type ValueType { get; init; }

    public IReadOnlyList<string> Identifiers
    {
        get => _identifiers.AsReadOnly();
    }

    public ArgAttribute(string[] identifiers)
    {
        if (identifiers.Length < 1)
        {
            throw new ArgumentException("Identifiers collection must contain at least one element.");
        }

        _identifiers = new(identifiers);

        MainIdentifier = identifiers[0];

        Id = Guid.NewGuid();

        ValueType = typeof(bool);
    }
}