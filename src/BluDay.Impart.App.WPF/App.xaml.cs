namespace BluDay.Impart.App.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public sealed partial class App : Application
{
    private IImpartApp? _app;

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var args = ArgumentsParser.Parse<ImpartAppArgs>(e.Args);

        _app = new ImpartApp(args);

        _app.Initialize();
    }
}