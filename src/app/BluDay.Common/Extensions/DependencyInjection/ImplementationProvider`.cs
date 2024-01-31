namespace BluDay.Common.Extensions.DependencyInjection;

public class ImplementationProvider<TService> : IImplementationProvider<TService> where TService : notnull
{
    private readonly IServiceProvider _serviceProvider;

    private static readonly Type _serviceType;

    private static readonly IReadOnlyDictionary<Type, IObjectFactorySite> _objectFactorySiteMap;

    Type IImplementationProvider.ServiceType => _serviceType;

    public static Type ServiceType => _serviceType;

    static ImplementationProvider()
    {
        _serviceType = typeof(TService);

        _objectFactorySiteMap = CreateMappedObjectFactorySites();
    }

    public ImplementationProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private object CreateInstance(IObjectFactorySite site)
    {
        return site.Factory.Invoke(_serviceProvider, arguments: null);
    }

    private static IReadOnlyDictionary<Type, IObjectFactorySite> CreateMappedObjectFactorySites()
    {
        return _serviceType
            .GetImplementationTypes()
            .Select(ObjectFactorySiteFactory.Create<TService>)
            .ToDictionary(
                keySelector:     site => site.Info.ImplementationType,
                elementSelector: site => site
            )
            .AsReadOnly();
    }

    public object GetInstance(Type implementationType)
    {
        if (!implementationType.IsAssignableTo(_serviceType))
        {
            throw new ArgumentException($"Implementation type {implementationType} must be of type {_serviceType}.");
        }

        IObjectFactorySite site = _objectFactorySiteMap[implementationType];

        return CreateInstance(site);
    }

    public TImplementation GetInstance<TImplementation>() where TImplementation : TService, new()
    {
        IObjectFactorySite site = _objectFactorySiteMap[typeof(TImplementation)];

        return (TImplementation)CreateInstance(site);
    }
}