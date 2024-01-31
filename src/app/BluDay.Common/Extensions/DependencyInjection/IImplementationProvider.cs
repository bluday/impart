namespace BluDay.Common.Extensions.DependencyInjection;

public interface IImplementationProvider
{
    Type ServiceType { get; }

    object GetInstance(Type implementationType);
}