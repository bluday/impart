namespace Impart.WinUI.UI;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public IServiceProvider ServiceProvider { get; }

    public DisplayArea DisplayArea { get; }

    public InputNonClientPointerSource NonClientPointerSource { get; }

    public MainWindow(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        DisplayArea            = AppWindow.GetDisplayArea();
        NonClientPointerSource = AppWindow.GetNonClientPointerSource();

        InitializeComponent();

        ConfigureAppWindow();
        ConfigureTitleBar();

        ContentFrame.Navigate<IntroductionPage>(ServiceProvider);
    }

    private void ConfigureAppWindow()
    {
        AppWindow.MakeTitleBarTransparent();
        AppWindow.SetIsResizable(false);
        AppWindow.Resize(2000, 1400);
        AppWindow.MoveToCenter(DisplayArea);
    }

    private void ConfigureTitleBar()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);
    }
}