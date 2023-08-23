using BluDay.Common.DependencyInjection;

namespace BluDay.Common.Exceptions
{
    public sealed class BluNullServiceInstanceException : System.Exception
    {
        public BluNullServiceInstanceException(BluServiceDescriptor descriptor)
            : base($"Cannot add null service for descriptor {descriptor} to scope.") { }
    }
}