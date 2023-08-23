namespace BluDay.Common.DependencyInjection
{
    public interface IBluServiceProvider
    {
        object Resolve(System.Type serviceType);

        object ResolveRequired(System.Type serviceType);
    }
}