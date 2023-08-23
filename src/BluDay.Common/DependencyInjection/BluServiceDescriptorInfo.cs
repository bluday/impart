namespace BluDay.Common.DependencyInjection
{
    public sealed class BluServiceDescriptorInfo
    {
        private readonly BluServiceDescriptor _descriptor;

        public System.Type ServiceType => _descriptor.ServiceType;

        public System.Type ImplementationType => _descriptor.ImplementationType;

        public BluServiceLifetime Lifetime => _descriptor.Lifetime;

        public BluServiceDescriptorInfo(BluServiceDescriptor descriptor)
        {
            BluValidator.NotNull(descriptor, nameof(descriptor));

            _descriptor = descriptor;
        }

        public override string ToString() => _descriptor.ToString();
    }
}