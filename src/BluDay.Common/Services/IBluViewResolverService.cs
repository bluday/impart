namespace BluDay.Common.Services
{
    public interface IBluViewResolverService
    {
        System.Collections.Generic.IReadOnlyCollection<System.Type> ResolvableViewTypes { get; }
    }
}