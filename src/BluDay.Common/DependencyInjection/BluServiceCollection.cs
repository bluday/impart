using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BluDay.Common.DependencyInjection
{
    public sealed class BluServiceCollection
    {
        private readonly HashSet<BluServiceDescriptor> _descriptors
            = new HashSet<BluServiceDescriptor>();

        public BluServiceDescriptor[] Descriptors => _descriptors.BluToArray();

        public bool Add(
            Type                              serviceType,
            Type                              implementationType,
            BluServiceLifetime                lifetime,
            object                            instance,
            Func<IBluServiceProvider, object> factory)
        {
            var descriptor = new BluServiceDescriptor(
                serviceType,
                implementationType,
                lifetime,
                instance,
                factory
            );

            return _descriptors.Add(descriptor);
        }

        public BluContainer BuildContainer()
        {
            return new BluContainer(services: this);
        }
    }
}