namespace BluDay.Common.Extensions.DependencyInjection;

public static class ObjectFactorySiteFactory
{
    public static IObjectFactorySite Create(Type serviceType, Type implementationType)
    {
        Type genericType = typeof(ObjectFactorySite<,>).MakeGenericType(serviceType, implementationType);

        return (IObjectFactorySite)Activator.CreateInstance(genericType)!;
    }

    public static IObjectFactorySite Create<TService>(Type implementationType)
    {
        return Create(typeof(TService), implementationType);
    }
}