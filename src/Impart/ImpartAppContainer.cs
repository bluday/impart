namespace Impart;

internal sealed class ImpartAppContainer : IDisposable
{
    private readonly IImpartApp _app;

    private readonly IServiceCollection _services;

    public IServiceProvider ServiceProvider { get; }

    public IReadOnlyList<ServiceDescriptor> ServiceDescriptors { get; }

    public ImpartAppContainer(IImpartApp app)
    {
        _app = app;

        _services = CreateServices();

        ServiceDescriptors = _services.AsReadOnly();

        ServiceProvider = _services.BuildServiceProvider();
    }

    private static IServiceCollection CreateServices()
    {
        return new ServiceCollection()
            .AddSingleton<IDialogService, DialogService>()
            .AddSingleton<IWindowService, WindowService>()
            .AddSingleton<IViewModelProvider, ViewModelProvider>();
    }

    public void InitializeCoreServices()
    {
        // Test.
        ServiceProvider
            .GetRequiredService<IWindowService>()
            .CreateWindow();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}