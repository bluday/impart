using System;

using Collection = BluDay.Common.DependencyInjection.BluServiceCollection;
using Lifetime   = BluDay.Common.DependencyInjection.BluServiceLifetime;
using Provider   = BluDay.Common.DependencyInjection.IBluServiceProvider;

namespace BluDay.Common.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static Collection Add<TImplementation>(
            this Collection                      source,
                 Lifetime                        lifetime = Lifetime.Singleton,
                 TImplementation                 instance = null,
                 Func<Provider, TImplementation> factory  = null
        )
            where TImplementation : class
        {
            return source.Add<TImplementation, TImplementation>(lifetime, instance, factory);
        }

        public static Collection Add<TService, TImplementation>(
            this Collection                      source,
                 Lifetime                        lifetime = Lifetime.Singleton,
                 TImplementation                 instance = null,
                 Func<Provider, TImplementation> factory  = null
        )
            where TService        : class
            where TImplementation : class
        {
            source.Add(
                serviceType:        typeof(TService), 
                implementationType: typeof(TImplementation),
                lifetime,
                instance,
                factory
            );

            return source;
        }

        #region Singleton
        public static Collection AddSingleton<TImplementation>(this Collection source)
            where TImplementation : class
        {
            return source.Add<TImplementation>();
        }

        public static Collection AddSingleton<TService, TImplementation>(this Collection source)
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>();
        }

        public static Collection AddSingleton<TImplementation>(
            this Collection      source,
                 TImplementation instance
        )
            where TImplementation : class
        {
            return source.Add(instance: instance);
        }

        public static Collection AddSingleton<TService, TImplementation>(
            this Collection      source,
                 TImplementation instance
        )
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(instance: instance);
        }

        public static Collection AddSingleton<TImplementation>(
            this Collection                      source,
                 Func<Provider, TImplementation> factory
        )
            where TImplementation : class
        {
            return source.Add(factory: factory);
        }

        public static Collection AddSingleton<TService, TImplementation>(
            this Collection                      source,
                 Func<Provider, TImplementation> factory
        )
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(factory: factory);
        }
        #endregion

        #region Scoped
        public static Collection AddScoped<TImplementation>(this Collection source)
            where TImplementation : class
        {
            return source.Add<TImplementation>(Lifetime.Scoped);
        }

        public static Collection AddScoped<TService, TImplementation>(this Collection source)
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(Lifetime.Scoped);
        }

        public static Collection AddScoped<TImplementation>(
            this Collection      source,
                 TImplementation instance
        )
            where TImplementation : class
        {
            return source.Add(Lifetime.Scoped, instance);
        }

        public static Collection AddScoped<TService, TImplementation>(
            this Collection      source,
                 TImplementation instance
        )
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(Lifetime.Scoped, instance);
        }

        public static Collection AddScoped<TImplementation>(
            this Collection                      source,
                 Func<Provider, TImplementation> factory
        )
            where TImplementation : class
        {
            return source.Add(Lifetime.Scoped, null, factory);
        }

        public static Collection AddScoped<TService, TImplementation>(
            this Collection                      source,
                 Func<Provider, TImplementation> factory
        )
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(Lifetime.Scoped, null, factory);
        }
        #endregion

        #region Transient
        public static Collection AddTransient<TImplementation>(this Collection source)
            where TImplementation : class
        {
            return source.Add<TImplementation>(Lifetime.Transient);
        }

        public static Collection AddTransient<TService, TImplementation>(this Collection source)
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(Lifetime.Transient);
        }

        public static Collection AddTransient<TImplementation>(
            this Collection      source,
                 TImplementation instance
        )
            where TImplementation : class
        {
            return source.Add(Lifetime.Transient, instance);
        }

        public static Collection AddTransient<TService, TImplementation>(
            this Collection      source,
                 TImplementation instance
        )
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(Lifetime.Transient, instance);
        }

        public static Collection AddTransient<TImplementation>(
            this Collection                      source,
                 Func<Provider, TImplementation> factory
        )
            where TImplementation : class
        {
            return source.Add(Lifetime.Transient, null, factory);
        }

        public static Collection AddTransient<TService, TImplementation>(
            this Collection                      source,
                 Func<Provider, TImplementation> factory
        )
            where TService        : class
            where TImplementation : class
        {
            return source.Add<TService, TImplementation>(Lifetime.Transient, null, factory);
        }
        #endregion
    }
}