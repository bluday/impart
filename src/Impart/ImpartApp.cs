namespace Impart;

public sealed class ImpartApp : IImpartApp
{
    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public string? Args { get; private set; }

    public IServiceProvider ServiceProvider { get; }

    public IReadOnlyList<ServiceDescriptor> ServiceDescriptors { get; }

    public ImpartApp()
    {
        IServiceCollection services = CreateServiceDescriptors();

        ServiceProvider = services.BuildServiceProvider();

        ServiceDescriptors = services.AsReadOnly();
    }

    private void InitializeServices()
    {
        // Temporary solution.
        ServiceProvider
            .GetRequiredService<IWindowService>()
            .CreateWindow();
    }

    private static IServiceCollection CreateServiceDescriptors()
    {
        return new ServiceCollection()
            .AddSingleton<IDialogService, DialogService>()
            .AddSingleton<IWindowService, WindowService>()
            .AddSingleton<IViewModelProvider, ViewModelProvider>();
    }

    public void Initialize()
    {
        Initialize(args: null);
    }

    public void Initialize(string? args)
    {
        if (IsInitialized) return;

        Args = args;

        InitializeServices();

        // Do other stuff, maybe?

        IsInitialized = true;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}