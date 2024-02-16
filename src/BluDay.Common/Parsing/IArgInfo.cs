namespace BluDay.Common.Parsing;

public interface IArgInfo
{
    ArgActionType ActionType { get; init; }

    object? Constant { get; init; }

    string MainIdentifier { get; }

    string? Description { get; init; }

    Guid Id { get; }

    Type ValueType { get; init; }

    IReadOnlyList<string> Identifiers { get; }
}