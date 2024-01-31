namespace BluDay.Impart.App.WinUI.UI.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window
{
    public InputNonClientPointerSource NonClientPointerSource { get; }

    public DisplayArea DisplayArea { get; }

    public WindowActivationState? ActivationState { get; private set; }

    public bool IsActivated
    {
        get => ActivationState is not WindowActivationState.Deactivated;
    }

    public bool IsClosed { get; private set; }

    public Shell()
    {
        NonClientPointerSource = AppWindow.GetNonClientPointerSource();
        DisplayArea            = AppWindow.GetDisplayArea();
        
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        AppWindow.MakeTitleBarTransparent();

        InitializeComponent();
    }

    private void Window_Activated(object sender, WindowActivatedEventArgs args)
    {
        ActivationState = args.WindowActivationState;

        Activated -= Window_Activated;
    }

    private void Window_Closed(object sender, WindowEventArgs args)
    {
        IsClosed = true;

        Closed -= Window_Closed;
    }
}