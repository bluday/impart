namespace BluDay.Extensions.DependencyInjection;

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

    public static ObjectFactory CreateImplicitFactory(ObjectFactory<TImplementation> implementationFactory)
    {
        return (IServiceProvider serviceProvider, object[] arguments) =>
        {
            return implementationFactory.Invoke(serviceProvider, arguments);
        }!;
    }

    public static ObjectFactory<TImplementation> CreateImplementationFactory()
    {
        return ActivatorUtilities.CreateFactory<TImplementation>(argumentTypes: Type.EmptyTypes);
    }
}