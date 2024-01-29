namespace Impart;

internal sealed class ImpartAppContainer : IDisposable
{
    private readonly IImpartApp _app;

    public static IServiceCollection ServiceDescriptors { get; } = new ServiceCollection();

    public IServiceProvider ServiceProvider { get; private set; }

    static ImpartAppContainer()
    {
        ConfigureServices();
    }

    public ImpartAppContainer(IImpartApp app)
    {
        _app = app;

        ServiceProvider = ServiceDescriptors.BuildServiceProvider();
    }

    private static void ConfigureServices()
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