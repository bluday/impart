namespace BluDay.Common.Extensions.DependencyInjection;

public sealed class ObjectFactoryInfo<TService, TImplementation> : IObjectFactoryInfo
    where TService        : class
    where TImplementation : TService, new()
{
    public Type ServiceType { get; } = typeof(TService);

    public Type ImplementationType { get; } = typeof(TImplementation);
}