namespace Impart;

internal sealed class ImpartAppContainer : IDisposable
{
    private readonly ImpartApp _app;

    private readonly ServiceProvider _serviceProvider;

    private readonly IServiceCollection _serviceDescriptors;

    public IServiceProvider ServiceProvider => _serviceProvider;

    public IReadOnlyList<ServiceDescriptor> ServiceDescriptors
    {
        get => _serviceDescriptors.AsReadOnly();
    }

    public ImpartAppContainer(ImpartApp app)
    {
        _app = app;

        _serviceDescriptors = CreateServiceDescriptors();

        _serviceProvider = _serviceDescriptors.BuildServiceProvider();
    }

    private static IServiceCollection CreateServiceDescriptors()
    {
        return new ServiceCollection()
            .AddSingleton<IDialogService, DialogService>()
            .AddSingleton<IWindowService, WindowService>()
            .AddSingleton<INavigationService, NavigationService>()
            .AddSingleton<IViewModelProvider, ViewModelProvider>();
    }

    public void InitializeCoreServices()
    {
        // TODO: Find a good way to "pre-initialize" services on launch.

        _serviceProvider
            .GetRequiredService<IWindowService>()
            .CreateWindow();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}