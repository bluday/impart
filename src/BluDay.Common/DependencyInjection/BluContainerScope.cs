using BluDay.Common.Exceptions;
using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BluDay.Common.DependencyInjection
{
    public sealed class BluContainerScope : IBluServiceProvider, IDisposable
    {
        private readonly BluContainer _container;

        private readonly HashSet<object> _services = new HashSet<object>();

        public bool Disposed { get; private set; }

        public int ServicesCount => _services.Count;

        public Guid Id { get; } = Guid.NewGuid();

        public BluContainerScope(BluContainer container)
        {
            BluValidator.NotNull(container, nameof(container));

            _container = container;
        }

        private object CreateServiceInstance(BluServiceDescriptor descriptor)
        {
            return descriptor?.Instance ?? descriptor?.Factory(this);
        }

        private object GetServiceInstance(Type implementationType)
        {
            return _services.BluFirst(service => service.GetType() == implementationType);
        }

        public void Dispose()
        {
            if (Disposed) return;

            foreach (object service in _services)
            {
                (service as IDisposable)?.Dispose();
            }

            _services.Clear();

            Disposed = true;
        }

        public object Resolve(Type serviceType)
        {
            try
            {
                return ResolveRequired(serviceType);
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public object ResolveRequired(Type serviceType)
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(ToString());
            }

            if (serviceType == typeof(IBluServiceProvider))
            {
                return this;
            }

            var descriptor = _container.GetServiceDescriptor(serviceType);

            if (descriptor is null)
            {
                throw new BluUnregisteredServiceException(serviceType);
            }

            object service = GetServiceInstance(descriptor.ImplementationType);

            if (service is null || descriptor.Lifetime is BluServiceLifetime.Transient)
            {
                service = CreateServiceInstance(descriptor);

                if (service is null)
                {
                    throw new BluNullServiceInstanceException(descriptor);
                }

                _services.Add(service);
            }

            return service;
        }

        public override string ToString()
        {
            return $"{nameof(BluContainerScope)}<{Id}> (Disposed: {Disposed})";
        }
    }
}