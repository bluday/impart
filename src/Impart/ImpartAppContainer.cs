namespace Impart;

internal sealed class ImpartAppContainer : IDisposable
{
    private readonly IImpartApp _app;

    public IServiceCollection ServiceDescriptors { get; } = new ServiceCollection();

    public IServiceProvider ServiceProvider { get; }

    public ImpartAppContainer(IImpartApp app)
    {
        _app = app;

        ConfigureServices();

        ServiceProvider = ServiceDescriptors.BuildServiceProvider();
    }

    private void ConfigureServices()
    {
        ServiceDescriptors
            .AddSingleton<IDialogService, DialogService>()
            .AddSingleton<IWindowService, WindowService>()
            .AddSingleton<IViewModelProvider, ViewModelProvider>();
    }

    public void InitializeCoreServices()
    {
        ServiceProvider
            .GetRequiredService<IWindowService>()
            .CreateWindow();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}