namespace Impart.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    public IServiceProvider ServiceProvider { get; } = CreateServices();

    public string? LaunchArgs { get; private set; }

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App() => InitializeComponent();

    private static IServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddSingleton<IWindowService, WindowService>()
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

        // Use WeakReferenceMessager to send a message to IWindowService or activate directly?
        ServiceProvider
            .GetRequiredService<IWindowService>()
            .ActivateMainWindow();
    }
}