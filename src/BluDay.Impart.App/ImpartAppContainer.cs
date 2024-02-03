namespace BluDay.Impart.App;

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
            .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
            .AddSingleton<IAppDialogService, AppDialogService>()
            .AddSingleton<IAppNavigationService, AppNavigationService>()
            .AddSingleton<IAppThemeService, AppThemeService>()
            .AddSingleton<IAppWindowService, AppWindowService>()
            .AddSingleton<IViewModelProvider, ViewModelProvider>();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}