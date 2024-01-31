namespace BluDay.Common.Extensions.DependencyInjection;

public class ImplementationProvider<TService> : IImplementationProvider<TService> where TService : notnull
{
    private readonly IReadOnlyDictionary<Type, IObjectFactorySite> _objectFactorySiteMap = CreateMappedObjectFactorySites();

    private readonly IServiceProvider _serviceProvider;

    public Type ServiceType { get; } = typeof(TService);

    public ImplementationProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private static IReadOnlyDictionary<Type, IObjectFactorySite> CreateMappedObjectFactorySites()
    {
        return typeof(TService)
            .GetImplementationTypes()
            .Select(ObjectFactorySiteFactory.Create<TService>)
            .ToDictionary(
                keySelector:     site => site.Info.ImplementationType,
                elementSelector: site => site
            )
            .AsReadOnly();
    }

    public TImplementation GetInstance<TImplementation>() where TImplementation : TService, new()
    {
        return (TImplementation)GetInstance(typeof(TImplementation));
    }

    public object GetInstance(Type implementationType)
    {
        IObjectFactorySite site = _objectFactorySiteMap[implementationType];

        return site.Factory.Invoke(_serviceProvider, arguments: null);
    }
}