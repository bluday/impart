namespace BluDay.Common.DependencyInjection.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IBluServiceProvider Initialize<TService>(this IBluServiceProvider provider)
            where TService : class
        {
            provider.ResolveRequired(typeof(TService));

            return provider;
        }

        public static TService Resolve<TService>(this IBluServiceProvider provider)
            where TService : class
        {
            return (TService)provider.Resolve(typeof(TService));
        }

        public static TService ResolveRequired<TService>(this IBluServiceProvider provider)
            where TService : class
        {
            return (TService)provider.ResolveRequired(typeof(TService));
        }
    }
}