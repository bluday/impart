using System;

namespace BluDay.Common.DependencyInjection
{
    public interface IBluContainer : IBluServiceProvider, IDisposable
    {
        bool Disposed { get; }

        int TotalServicesCount { get; }

        IBluServiceProvider RootProvider { get; }

        BluServiceDescriptorInfo[] RegisteredServices { get; }

        BluContainerScope CreateScope();

        BluServiceDescriptor GetServiceDescriptor(Type serviceType);

        BluServiceDescriptor[] GetServiceDescriptors(Type serviceType);
    }
}