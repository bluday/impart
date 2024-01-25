namespace Impart.WinUI.UI.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window
{
    public DisplayArea DisplayArea { get; }

    public InputNonClientPointerSource NonClientPointerSource { get; }

    public Shell()
    {
        DisplayArea            = AppWindow.GetDisplayArea();
        NonClientPointerSource = AppWindow.GetNonClientPointerSource();
        
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        AppWindow.MakeTitleBarTransparent();

        InitializeComponent();
    }
}