namespace BluDay.Common.Infrastructure.Models;

public abstract class Model : IModel, IEquatable<Model>, IEqualityComparer<Model>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool Equals(Model? other)
    {
        return Id == other?.Id;
    }

    public bool Equals(Model? x, Model? y)
    {
        return EqualityComparer<Model>.Default.Equals(x, y);
    }

    public int GetHashCode(Model obj)
    {
        return obj.GetHashCode() ^ obj.Id.GetHashCode();
    }
}