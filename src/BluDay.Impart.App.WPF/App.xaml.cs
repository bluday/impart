namespace BluDay.Impart.App.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public sealed partial class App : Application
{
    private IImpartApp? _app;

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _app = new ImpartApp(args: e.Args);

        _app.Initialize();
    }
}