namespace BluDay.Common.Extensions.DependencyInjection;

public static class ObjectFactorySiteFactory
{
    public static IObjectFactorySite Create([DisallowNull] Type serviceType, [DisallowNull] Type implementationType)
    {
        Type genericType = typeof(ObjectFactorySite<,>).MakeGenericType(serviceType, implementationType);

        return (IObjectFactorySite)Activator.CreateInstance(genericType)!;
    }
}