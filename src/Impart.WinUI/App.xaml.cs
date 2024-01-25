namespace Impart.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private MainWindow? _mainWindow;

    public IServiceProvider ServiceProvider { get; }

    public string? LaunchArgs { get; private set; }

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        ServiceProvider = CreateServices();

        InitializeComponent();
    }

    private static IServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddSingleton<MainWindow>()
            .AddTransient<ConversationsViewModel>()
            .AddTransient<IntroductionViewModel>()
            .AddTransient<MainViewModel>()
            .AddTransient<SettingsViewModel>()
            .BuildServiceProvider();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        LaunchArgs = args.Arguments;

        _mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

        _mainWindow.Activate();
    }
}