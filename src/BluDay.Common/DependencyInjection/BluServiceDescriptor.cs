using BluDay.Common;
using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BluDay.Common.DependencyInjection
{
    public sealed class BluServiceDescriptor
    {
        private readonly Func<object[], object> _constructor;

        private readonly Type[] _parameterTypes;

        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public BluServiceLifetime Lifetime { get; }

        public object Instance { get; }

        public Func<IBluServiceProvider, object> Factory { get; }

        public BluServiceDescriptorInfo Info { get; }

        public BluServiceDescriptor(
            Type                              serviceType,
            Type                              implementationType,
            BluServiceLifetime                lifetime,
            object                            instance,
            Func<IBluServiceProvider, object> factory)
        {
            implementationType = implementationType ?? factory?.Method.ReturnType;

            if (!(implementationType.IsInstantiatable() is true))
            {
                throw new ArgumentException(
                    "Implementation type must be of an instantiatable type."
                );
            }

            serviceType = serviceType ?? implementationType;

            var constructorInfo = implementationType.GetConstructors()[0];

            _constructor = constructorInfo.Invoke;

            _parameterTypes = constructorInfo.GetParameterTypes();

            ServiceType        = serviceType;
            ImplementationType = implementationType;

            Lifetime = lifetime;

            Instance = instance;

            Factory = factory ?? CreateTargetFactory();

            Info = new BluServiceDescriptorInfo(descriptor: this);
        }

        private Func<IBluServiceProvider, object[]> CreateDependenciesFactory()
        {
            var resolvers = new List<Func<IBluServiceProvider, object>>();

            foreach (Type parameter in _parameterTypes)
            {
                if (parameter.IsPrimitive)
                {
                    continue;
                }

                resolvers.Add(provider => provider.ResolveRequired(parameter));
            }

            return provider =>
            {
                BluValidator.NotNull(provider, nameof(provider));

                var dependencies = new object[resolvers.Count];

                for (int i = 0; i < resolvers.Count; i++)
                {
                    dependencies[i] = resolvers[i](provider);
                }

                return dependencies;
            };
        }

        public Func<IBluServiceProvider, object> CreateTargetFactory()
        {
            var dependenciesFactory = CreateDependenciesFactory();

            return provider => _constructor(dependenciesFactory(provider));
        }

        public override string ToString()
        {
            return "Service ({0}) <{1}, {2}>".BluFormat(
                Lifetime,
                ServiceType.Name,
                ImplementationType.Name
            );
        }
    }
}