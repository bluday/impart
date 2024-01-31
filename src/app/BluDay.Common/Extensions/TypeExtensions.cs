namespace BluDay.Common.Extensions;

public static class TypeExtensions
{
    public static bool IsImplementationType(this Type source, Type serviceType)
    {
        return source != serviceType
            && source.IsClass
            && source.IsAbstract is false
            && source.IsAssignableTo(serviceType);
    }

    public static IEnumerable<Type> GetImplementationTypes(this Type source)
    {
        return source.Assembly
            .GetTypes()
            .Where(type => type.IsImplementationType(source));
    }
}