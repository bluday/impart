using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BluDay.Common.DependencyInjection
{
    public sealed class BluContainer : IBluContainer
    {
        private readonly BluContainerScope _rootScope;

        private readonly HashSet<BluContainerScope> _scopes = new HashSet<BluContainerScope>();

        private readonly BluServiceDescriptor[] _descriptors;

        public bool Disposed { get; private set; }

        public int TotalServicesCount
        {
            get => _scopes.BluAggregateCount(scope => scope.ServicesCount);
        }

        public IBluServiceProvider RootProvider => _rootScope;

        public BluServiceDescriptorInfo[] RegisteredServices
        {
            get => _descriptors.BluSelect(descriptor => descriptor.Info);
        }

        public BluContainer(BluServiceCollection services)
        {
            _rootScope = CreateScope();

            _descriptors = services.Descriptors;
        }

        public object Resolve(Type serviceType)
        {
            return _rootScope.Resolve(serviceType);
        }

        public object ResolveRequired(Type serviceType)
        {
            return _rootScope.ResolveRequired(serviceType);
        }

        public void Dispose()
        {
            if (Disposed) return;

            foreach (var scope in _scopes)
            {
                scope.Dispose();
            }

            Disposed = true;
        }

        public BluContainerScope CreateScope()
        {
            return _scopes.BluAddAndReturn(new BluContainerScope(this));
        }

        public BluServiceDescriptor GetServiceDescriptor(Type serviceType)
        {
            return _descriptors.BluFirst(descriptor => descriptor.ServiceType == serviceType);
        }

        public BluServiceDescriptor[] GetServiceDescriptors(Type serviceType)
        {
            return _descriptors.BluWhere(descriptor => descriptor.ServiceType == serviceType);
        }
    }
}