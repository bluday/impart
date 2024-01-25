namespace Impart.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private readonly IWindowService _windowService;

    private readonly IServiceProvider _serviceProvider;

    public string? LaunchArgs { get; private set; }

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        _serviceProvider = CreateServices();

        _windowService = _serviceProvider.GetRequiredService<IWindowService>();

        InitializeComponent();
    }

    private static IServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddSingleton<IWindowService, WindowService>()
            .AddTransient<IViewModel, ConversationsViewModel>()
            .AddTransient<IViewModel, IntroductionViewModel>()
            .AddTransient<IViewModel, MainViewModel>()
            .AddTransient<IViewModel, SettingsViewModel>()
            .BuildServiceProvider();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        LaunchArgs = args.Arguments;

        // Create and activate the main window here.
    }
}