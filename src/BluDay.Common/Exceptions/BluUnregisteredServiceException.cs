namespace BluDay.Common.Exceptions
{
    public sealed class BluUnregisteredServiceException : System.Exception
    {
        public BluUnregisteredServiceException(System.Type serviceType)
            : base($"Service {serviceType} has not been registered.") { }
    }
}