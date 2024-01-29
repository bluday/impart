namespace Impart;

internal sealed class ImpartAppContainer : IDisposable
{
    private readonly IImpartApp _app;

    public IServiceCollection ServiceDescriptors { get; }

    public IServiceProvider ServiceProvider { get; }

    public ImpartAppContainer(IImpartApp app)
    {
        _app = app;

        ServiceDescriptors = CreateServiceDescriptors();

        ServiceProvider = ServiceDescriptors.BuildServiceProvider();
    }

    private static IServiceCollection CreateServiceDescriptors()
    {
        return new ServiceCollection()
            .AddSingleton<IDialogService, DialogService>()
            .AddSingleton<IWindowService, WindowService>()
            .AddSingleton<IViewModelProvider, ViewModelProvider>();
    }

    public void InitializeCoreServices()
    {
        ServiceProvider!
            .GetRequiredService<IWindowService>()
            .CreateWindow();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}