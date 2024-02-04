namespace BluDay.Common.Extensions.DependencyInjection;

public sealed class ObjectFactorySite<TService, TImplementation> : IObjectFactorySite
    where TService        : class
    where TImplementation : TService, new()
{
    private readonly ObjectFactory _implicitFactory;

    public ObjectFactoryInfo<TService, TImplementation> Info { get; } = new();

    public ObjectFactory<TImplementation> Factory { get; } = CreateImplementationFactory();

    IObjectFactoryInfo IObjectFactorySite.Info => Info;

    ObjectFactory IObjectFactorySite.Factory => _implicitFactory;

    public ObjectFactorySite()
    {
        _implicitFactory = CreateImplicitFactory(Factory);
    }

    public static ObjectFactory CreateImplicitFactory(ObjectFactory<TImplementation> factory)
    {
        return (IServiceProvider serviceProvider, object[] args) =>
        {
            return factory.Invoke(serviceProvider, args);
        }!;
    }

    public static ObjectFactory<TImplementation> CreateImplementationFactory()
    {
        return ActivatorUtilities.CreateFactory<TImplementation>(argumentTypes: Type.EmptyTypes);
    }
}